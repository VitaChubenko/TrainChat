var isGroupMessage = true;
var chat = $.connection.chatHub;

$(function () {
    //var chat = $.connection.chatHub;
    $('#listmessages').hide();
    $('#messagewindow').hide();

    chat.client.showAllUsers = function (allUsers) {
        $('#alluserslist').empty();
        for (i = 0; i < allUsers.length; i++) {
            AllUsers(allUsers[i]);
        }
        chat.server.colorAllOnlineUsers();
    };

    chat.client.colorOnlineUser = function (onlineUser, color) {
        var all = document.getElementsByClassName(onlineUser);
        for (var i = 0; i < all.length; i++) {
            all[i].style.backgroundColor = color;
        }
    };

    chat.client.addMessage = function (senderName, message, dateTime) {
        var thisUser = localStorage.getItem('login');
        if (thisUser == senderName) {
            $('#listmessages')
                .append('<div class =\'msg thumbnail\'  ' +
                    'style=\'float:right; border-radius: 15px; margin-bottom: 3px; margin-top: 3px\'>' +
                    '<span class="glyphicon glyphicon-user" style=\'margin-left:10px; color: rgb(196, 213, 235);\'/> <b style=\'font-size:13px; color: darkcyan;\'>' +
                    senderName +
                    ' </b><br>'+
                    message +
                    '<p>'  +
                    dateTime +
                    '</p></div>');        
        } else {
            $('#listmessages')
                .append('<div class =\'msg thumbnail\'  ' +
                    'style=\'float:left; border-radius: 15px; margin-bottom: 3px; margin-top: 3px\'>' +
                    '<span class="glyphicon glyphicon-user" style=\'margin-left:10px; color: rgb(196, 213, 235);\'/> <b style=\'font-size:13px; color: darkcyan;\'>' +
                    senderName +
                    ' </b><br>' +
                    message +
                    '<p>' +
                    dateTime +
                    '</p></div>');
        }           
    };

    chat.client.addServerMessage = function (message, dateTime) {
        $('#listmessages')
            .append('<div class =\'msg-server thumbnail\' > <br>' +
                message + dateTime + '</p></div>');
    };

    chat.client.onConnected = function (connectionId, userName, roomName, Users, allUsers) {
        $('#hdId').val(connectionId);
        $('#username').val(userName);
        $('#chattitle h1').text(roomName);
        $('title').text(roomName);
        //$('#alluserslist').empty();
        $('#listusers').empty();
        for (i = 0; i < Users.length; i++) {
            AddUser(Users[i]);
        };
        chat.server.colorAllOnlineUsers();
        $('.opponent').click(function () {
            $('#listmessages').empty();
            chat.server.connectToPrivateChat($(this).text(), $('#username').val());
            isGroupMessage = false;
            chat.server.colorAllOnlineUsers();
            chat.server.showMessageHistory($(this).text(), isGroupMessage);           
            $('#chattitle h1').text($(this).text());
        });
        //chat.client.showAllUsers(allUsers);
        var all = document.getElementsByClassName(userName);
        for (var i = 0; i < all.length; i++) {
            all[i].style.backgroundColor = "#c4d5eb";
        }
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
        var all = document.getElementsByClassName(localStorage.getItem('login'));
        for (var i = 0; i < all.length; i++) {
            all[i].style.backgroundColor = "#c4d5eb";
        }
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
                        chat.server.colorAllOnlineUsers();
                    });
            
            $('#sendmessage')
                .click(function () {                    
                    chat.server.sendMessage($('#chattitle h1').text(),
                        $('#username').val(),
                        $('#message').val(),
                        isGroupMessage);
                    $('#message').val('');
                });           
        });
});

function GetCulture(cultureName) {
    chat.server.SetCulture(cultureName);
};

function AddUser(userName) {
    $('#listusers').append('<div class=\'btn btn-default btn-block btn-xs text-left opponent ' + userName+'\' title=' + userName + '>' + userName + '</div>');
};

function AddChatRoom(chatRoom) {
    $('#listrooms').append('<button class=\'chatroom btn btn-default btn-block btn-xs text-left\' title=' + chatRoom + '>' + chatRoom + '</button>');
};

function AllUsers(userName) {
    $('#alluserslist').append('<div class=\'btn btn-default btn-block btn-xs text-left users ' +userName+'\' title=' + userName + '>' + userName + '</div>');
}

function Ban(id, isBanned) {
    chat.server.setBan(id, isBanned);
}

