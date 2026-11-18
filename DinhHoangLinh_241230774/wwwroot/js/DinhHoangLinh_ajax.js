$(function(){
    $('.js-category').on('click',function(){
        e.preventDefault();
        var link=$(this);
        $.get('/Home/TheoTheLoai',{id: link.data('id')},function(html){
            $('#book-list').html(html);
            $('#section-title').text(link.data('name'));
            $('.menu li').removeClass('active');
            link.closest('li').addClass('active');
        });
    });
});