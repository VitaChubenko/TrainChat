$(function() {

    var chat = $.connection.chatHub;
    $('#listmessages').hide();
    $('#messagewindow').hide();


    chat.client.showAllUsers = function (allUsers) {
        $('#alluserslist').empty();
        for (i = 0; i < allUsers.length; i++) {
            AllUsers(allUsers[i]);
        }
    };

    chat.client.addMessage = function(userName, message, dateTime) {
        var thisUser = localStorage.getItem('login');
        if (thisUser == userName) {
            $('#listmessages')
                .append('<div class =\'msg thumbnail\'  ' +
                    'style=\'float:right; border-radius: 15px; margin-bottom: 3px; margin-top: 3px\'>' +
                    message +
                    '<p> <b>' +
                    userName +
                    ' </b>' +
                    dateTime +
                    '</p></div>');
        } else {
            $('#listmessages')
                .append('<div class =\'msg thumbnail\'  ' +
                    'style=\'float:left; border-radius: 15px; margin-bottom: 3px; margin-top: 3px\'>' +
                    message +
                    '<p> <b>' +
                    userName +
                    ' </b>' +
                    dateTime +
                    '</p></div>');
        }
    };

    chat.client.addServerMessage = function(message, dateTime) {
        $('#listmessages')
            .append('<div class =\'msg-server thumbnail\' >' +
                message +
                '</p><br>' +
                userName +
                '<p>' +
                dateTime +
                '</p></div>');
    };
    //chat.client.addServerMessage = function (message, dateTime) {
    //    $('#listmessages').append('<div class =\'msg-server thumbnail\' >' + message + '<p> <b>'
    //        + userName + ' </b>' + dateTime + '</p></div>');
    //};

    chat.client.onConnected = function(connectionId, userName, roomName, Users, allUsers) {
        $('#hdId').val(connectionId);
        $('#username').val(userName);
        $('#chattitle h1').text(roomName);
        $('title').text(roomName);
        $('#alluserslist').empty();
        $('#listusers').empty();
        for (i = 0; i < Users.length; i++) {
            AddUser(Users[i]);
        };     
        chat.client.showAllUsers(allUsers);
        $('#listmessages').show().empty();
        $('#messagewindow').show();
    };

    chat.client.onNewUserConnected = function(Users) {
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

    chat.client.showAlert = function(message) {
        alert(message);
    };

    $.connection.hub.start()
        .done(function() {
            chat.server.getChatRoomsList();

            $(document)
                .on("click touchstart",
                    ".chatroom",
                    function() {
                        chat.server.connectToRoomChat($(this).text(), $('#username').val());
                    });

            $('#sendmessage')
                .click(function() {
                    var date = new Date();
                    var currDateTime = date.toLocaleDateString() +
                        '  ' +
                        date.toLocaleTimeString(navigator.language, { hour: '2-digit', minute: '2-digit' });
                    chat.server.sendMessage($('#chattitle h1').text(),
                        $('#username').val(),
                        $('#message').val(),
                        currDateTime);
                    $('#message').val('');
                });
        });

    $("#listmessages")
        .sortable({
            revert: true
        });
    $(".users")
        .sortable({
            connectToSortable: '#listmessages',
            helper: 'clone',
            opacity: '0.5'
        })
        .disableSelection();
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
                console.log("hiii");
                
            }
        });
});

function AddUser(userName) {
    $('#listusers').append('<p>' + userName + '</p>');
};

function AddChatRoom(chatRoom) {
    $('#listrooms').append('<button class=\'chatroom btn btn-default btn-block btn-xs text-left\' title='+chatRoom+'>' + chatRoom +'</button>');
};

function AllUsers(userName) {
    $('#alluserslist').append('<div class=\'btn btn-default btn-block btn-xs text-left users\' title=' + userName + 'id='+userName+'>' + userName + '</div>');
}
