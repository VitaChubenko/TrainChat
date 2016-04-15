function SetStyle() {
    var str = localStorage.getItem('href');
    swapStyleSheet(str);
}

function swapStyleSheet(sheet) {
    document.getElementById('pagestyle').setAttribute('href', sheet);
    localStorage.setItem('href', sheet);
}