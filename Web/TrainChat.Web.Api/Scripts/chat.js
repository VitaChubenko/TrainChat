var chat = $.connection.chatHub;
var isGroupMessage = true;

$(function () {
    
    $('#listmessages').hide();
    $('#messagewindow').hide(); 

    chat.client.showAllUsers = function (allUsers) {
        $('#alluserslist').empty();
        for (i = 0; i < allUsers.length; i++) {
            AllUsers(allUsers[i]);
        }
    };

    chat.client.addMessage = function (senderName, message, dateTime) {
        var thisUser = localStorage.getItem('login');
        if (thisUser == senderName) {
            $('#listmessages')
                .append('<div class =\'msg thumbnail\'  ' +
                    'style=\'float:right; border-radius: 15px; margin-bottom: 3px; margin-top: 3px\'>' +
                    message +
                    '<p> <b>' +
                    senderName +
                    ' </b>' +
                    dateTime +
                    '</p></div>');        
        } else {
            $('#listmessages')
                .append('<div class =\'msg thumbnail\'  ' +
                    'style=\'float:left; border-radius: 15px; margin-bottom: 3px; margin-top: 3px\'>' +
                    message +
                    '<p> <b>' +
                    senderName +
                    ' </b>' +
                    dateTime +
                    '</p></div>');
        }           
    };

    chat.client.addServerMessage = function (message, dateTime) {
        $('#listmessages')
            .append('<div class =\'msg-server thumbnail\' >' +
                message +
                '</p><br>' +
                userName +
                '<p>' +
                dateTime +
                '</p></div>');
    };

    chat.client.onConnected = function (connectionId, userName, roomName, Users, allUsers) {
        $('#hdId').val(connectionId);
        $('#username').val(userName);
        $('#chattitle h1').text(roomName);
        $('title').text(roomName);
        $('#alluserslist').empty();
        $('#listusers').empty();
        for (i = 0; i < Users.length; i++) {
            AddUser(Users[i]);
        };
        $('.opponent').click(function () {
            debugger;
            $('#listmessages').empty();
            chat.server.connectToPrivateChat($(this).text(), $('#username').val());
            isGroupMessage = false;
            chat.server.showMessageHistory($(this).text(), isGroupMessage);           
            $('#chattitle h1').text($(this).text());
        });
        chat.client.showAllUsers(allUsers);
        $('#listmessages').show().empty();
        $('#messagewindow').show();
       
        $("#listmessages")
        .sortable({
            revert: true
        });

        $(".users")
            .sortable({
                connectToSortable: '#listmessages',
                helper: 'clone',
                opacity: '0.5'           
            }).disableSelection();

        $(".users")
            .draggable({
                connectWith: "#listmessages",
                helper: "clone",
                opacity: "0.5",
                zIndex: 10
            });        

        $("#listmessages")
            .droppable({
                accept: ".users",
                drop: function (event, ui) {
                    var userName = $(ui.draggable).attr("id");
                    console.log($(ui.draggable).attr("id"));
                    chat.server.addUserToRoom(roomName, userName);
                }
            });
    };

    chat.client.onNewUserConnected = function (Users) {
        $('#listusers').empty();
        for (i = 0; i < Users.length; i++) {
            AddUser(Users[i]);
        };
    };

    chat.client.getGetChatRoomsList = function (chatRooms) {
        $('#listrooms').empty();
        for (i = 0; i < chatRooms.length; i++) {
            AddChatRoom(chatRooms[i]);
        }
    };

    chat.client.showAlert = function (message) {
        alert(message);
    };

    $.connection.hub.start()
        .done(function () {
            chat.server.getChatRoomsList();

            $(document)
                .on("click touchstart",
                    ".chatroom",
                    function () {
                        chat.server.connectToRoomChat($(this).text(), $('#username').val());
                        isGroupMessage = true;
                        chat.server.showMessageHistory($(this).text(), isGroupMessage);
                    });

            //$(document)
            //    .on("click touchstart",
            //        ".opponent",
            //        function () {
            //            debugger;
            //            chat.server.connectToRoomChat($(this).text(), $('#username').val());
            //            isGroupMessage = false;
            //            chat.server.showMessageHistory($(this).text(), isGroupMessage);
            //        });
            
            $('#sendmessage')
                .click(function () {                    
                    //var date = new Date();
                    //var currDateTime = date.toLocaleDateString() +
                    //    '  ' +
                    //    date.toLocaleTimeString(navigator.language, { hour: '2-digit', minute: '2-digit' });
                    chat.server.sendMessage($('#chattitle h1').text(),
                        $('#username').val(),
                        $('#message').val(),
                        isGroupMessage);
                    $('#message').val('');
                });           
        });
});

function AddUser(userName) {
    $('#listusers').append('<div class=\'btn btn-default btn-block btn-xs text-left opponent\' title=' + userName + ' id=' + userName + '>' + userName + '</div>');
};

function AddChatRoom(chatRoom) {
    $('#listrooms').append('<button class=\'chatroom btn btn-default btn-block btn-xs text-left\' title=' + chatRoom + '>' + chatRoom + '</button>');
};

function AllUsers(userName) {
    $('#alluserslist').append('<div class=\'btn btn-default btn-block btn-xs text-left users\' title=' + userName + ' id=' + userName + '>' + userName + '</div>');
}

function Ban(id, isBanned) {
    chat.server.setBan(id, isBanned);
}

