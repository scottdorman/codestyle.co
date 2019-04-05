$(function () {
    $.localScroll({ filter: '#markdown-toc a' });
    $('#goTop').goTop({
        "src": "fas fa-chevron-up"
    });
});