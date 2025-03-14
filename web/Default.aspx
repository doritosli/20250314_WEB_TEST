<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <a href='#C' title='中央內容區塊' id='gotocenter' accesskey='C' name='gotocenter' onfocus='OnFocus()' onblur='UnFocus()'>:::</a>
    <h1 id="aspnetTitle">--測試網站--</h1>

    <div class="row">
        <div class="col-md-12" id="File_Download" runat="server" style="padding-top: 20px">
            <h2>1.檔案下載</h2>
            <p><a href="/Download/File_Download" class="btn btn-primary btn-md">more</a></p>
        </div>
        <div class="col-md-12" id="User_Login" runat="server" style="padding-top: 20px">
            <h2>2.會員登入</h2>
            <p><a href="/Login/User_Login" class="btn btn-primary btn-md">more</a></p>
        </div>
        <div style="background-color: #F8EBEF">
            <div class="container pt-3">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="py-3 d-flex align-items-center justify-content-between">
                            <div style="width: 10%"></div>
                            <div class="h1" style="color: #B52455; font-size: 4em;"><strong>活動相片</strong></div>
                            <a href="Album_Data/Album_Data_Present" title="更多活動相片" style="font-size: x-large">more</a>
                        </div>
                        <!-- Swiper -->
                        <div>
                            <div id="WEB_ALBUM" runat="server"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="/Scripts/jquery.min.js"></script>
    <script src="/Scripts/owl.carousel.min.js"></script>
    <style type="text/css">
        :focus {
            outline-width: 5px !important;
            outline-style: groove !important;
            outline-color: red !important;
            box-shadow: none !important;
        }

        a {
            display: inline-block;
        }

        .owl-theme .item {
            padding: 1rem;
        }

        .owl-prev, .owl-next {
            width: 15px;
            height: 100px;
            position: absolute;
            top: 50%;
            transform: translateY(-50%);
            display: block !important;
            border: 0px solid black;
            background: 0;
        }

        .owl-theme .owl-prev {
            left: -10px;
        }

        .owl-theme .owl-next {
            right: -10px;
        }

        .owl-prev i, .owl-next i {
            transform: scale(2,5);
            color: #ccc;
        }
    </style>
    <script>
        //活動相片
        $(function () {
            var owl = $('.W6');
            $('.play6').on('click', function () {
                owl.trigger('play.owl.autoplay', [5000])
            });
            $('.stop6').on('click', function () {
                owl.trigger('stop.owl.autoplay', [5000])
            });
        });
        //活動相片
        function ALBUM(position) {
            var carousel = $(".W6");
            carousel.owlCarousel();
            carousel.trigger("to.owl.carousel", [position, 0, true]);
            carousel.trigger("stop.owl.autoplay", [5000]);
        }
        function ALBUM1(position) {
            var carousel = $(".W6");
            carousel.owlCarousel();
            carousel.trigger("play.owl.autoplay", [5000]);
        }
        //活動相片
        $(".W6").owlCarousel({
            loop: true, // 循環播放
            margin: 10, // 外距 10px
            nav: true, // 顯示點點
            autoplay: true,
            autoplayTimeout: 5000,
            autoplayHoverPause: true,
            rewind: true,
            responsive: {
                0: {
                    items: 1 // 螢幕大小為 0~600 顯示 1 個項目
                },
                600: {
                    items: 3 // 螢幕大小為 600~1000 顯示 3 個項目
                }
            }
        });
        $('.W6').each(function () {
            //Find each set of dots in this carousel
            $(this).find('.owl-dot').each(function (index) {
                //Add one to index so it starts from 1
                $(this).attr('aria-label', '下一個輪播畫面');
            });
        });
        $('#slideshow6 .owl-prev').attr('role', 'button').attr('title', '上一個');
        $('#slideshow6 .owl-next').attr('role', 'button').attr('title', '下一個');
        $('.W6').find('.owl-nav').removeClass('disabled');
        $('.W6').on('changed.owl.carousel', function (event) {
            $(this).find('.owl-nav').removeClass('disabled');
        });
        $('.W6').find('.owl-dots').removeClass('disabled');
        $('.W6').on('changed.owl.carousel', function (event) {
            $(this).find('.owl-dots').removeClass('disabled');
        });
    </script>
</asp:Content>
