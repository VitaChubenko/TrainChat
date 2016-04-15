$(function () {

    var chat = $.connection.chatHub;
    $('#listmessages').hide();
    $('#messagewindow').hide();

    chat.client.addMessage = function (userName, message, dateTime) {
        $('#listmessages').append('<div class =\'msg thumbnail\' ><b>' + userName + '</b>   '
            + dateTime + '<p>' + message + '</p></div>');
    };

    chat.client.addServerMessage = function (message, dateTime) {
        $('#listmessages').append('<div class =\'msg-server thumbnail\' ><b>Server message</b>   '
            + dateTime + '<p>' + message + '</p></div>');
    };

    chat.client.onConnected = function (connectionId, userName, roomName, Users) {
        $('#hdId').val(connectionId);
        $('#username').val(userName);
        $('#chattitle h1').text(roomName);
        $('title').text(roomName);
        $('#listusers').empty();
        for (i = 0; i < Users.length; i++) {
            AddUser(Users[i]);
        };
        $('#listmessages').show().empty();
        $('#messagewindow').show();
    };

    chat.client.onNewUserConnected = function (Users) {
        $('#listusers').empty();
        for (i = 0; i < Users.length; i++) {
            AddUser(Users[i]);
        };
    };

    chat.client.getGetChatRoomsList = function (chatRooms) {
        for (i = 0; i < chatRooms.length; i++) {
            AddChatRoom(chatRooms[i]);
        }
    };

    chat.client.showAlert = function (message) {
        alert(message);
    };

    $.connection.hub.start().done(function () {

        chat.server.getChatRoomsList();

        $(document).on("click touchstart", ".chatroom", function () {
            chat.server.connectToRoomChat($(this).text(), $('#username').val());
        });

        $('#sendmessage').click(function () {
            var date = new Date();
            var currDateTime = date.toLocaleDateString() + '  ' + date.toLocaleTimeString(navigator.language, { hour: '2-digit', minute: '2-digit' });
            chat.server.sendMessage($('#chattitle h1').text(), $('#username').val(), $('#message').val(), currDateTime);
            $('#message').val('');
        });
    });

});


function AddUser(userName) {
    $('#listusers').append('<p>' + userName + '</p>');
};

function AddChatRoom(chatRoom) {
    $('#listrooms').append('<button class=\'chatroom btn btn-default btn-block btn-xs text-left\'>' + chatRoom + '</button>');
};