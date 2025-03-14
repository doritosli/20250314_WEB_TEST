<%@ Page Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Album_Data_Present.aspx.cs" Inherits="web.Album_Data.Album_Data_Present" %>

<asp:Content ID="ContentM" ContentPlaceHolderID="MainContent" runat="server">
    <div style="background: #fffdf4;">
        <div class="container pt-3">
            <div class="row">
                <div class="col-md-12" id="Page_Maps" runat="server"></div>
                <div class="col-md-12" id="Page_Data" runat="server"></div>
                <div class="col-md-2"></div>
                <div class="col-md-8" id="Photo_Show" runat="server"></div>
                <div class="col-md-2"></div>
                <div class="col-md-12" id="Photo_Day" runat="server">
                </div>
                <div class="col-md-12" id="back" runat="server">
                    <a href="/Default" class="btn btn-info btn-md">BACK</a>
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
    </style>

    <%--輪播nav樣式--%>
    <style type="text/css">
        .owl-theme .item {
            padding: 1rem;
        }

        .owl-prev, .owl-next {
            width: 30px;
            height: 50px;
            position: absolute;
            top: 100%;
            transform: translateY(-50%);
            display: block !important;
            border: 0px solid black;
            background: 0;
        }

        .owl-prev {
            left: 0px;
        }

        .owl-next {
            right: 0px;
        }

            .owl-prev i, .owl-next i {
                transform: scale(2,5);
                color: #ccc;
            }

        #sync1 .item {
            color: #FFF;
            -webkit-border-radius: 3px;
            -moz-border-radius: 3px;
            border-radius: 3px;
            text-align: center;
        }

        #sync2 .item {
            padding: 1px 1px;
            margin: 5px;
            color: #FFF;
            -webkit-border-radius: 3px;
            -moz-border-radius: 3px;
            border-radius: 3px;
            text-align: center;
            cursor: pointer;
        }

            #sync2 .item h1 {
                font-size: large;
            }

        #sync2 .current .item {
            /*background: #0963AD;*/
        }

        .owl-theme .owl-nav {
            /*default owl-theme theme reset .disabled:hover links */
        }

            .owl-theme .owl-nav [class*='owl-'] {
                transition: all .3s ease;
            }

                .owl-theme .owl-nav [class*='owl-'].disabled:hover {
                    background-color: #D6D6D6;
                }

        #sync1.owl-theme {
            position: relative;
        }

            #sync1.owl-theme .owl-next, #sync1.owl-theme .owl-prev {
                width: 22px;
                height: 40px;
                margin-top: -20px;
                position: absolute;
                top: 50%;
            }

            #sync1.owl-theme .owl-prev {
                left: -10px;
            }

            #sync1.owl-theme .owl-next {
                right: -10px;
            }

        .ifrm {
            border: none;
            width: 50%;
            margin-top: 50px;
        }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {

            var sync1 = $("#sync1");
            var sync2 = $("#sync2");
            var slidesPerPage = 3; //縮圖顯示5小張
            var syncedSecondary = true;

            sync1.owlCarousel({
                items: 1,
                margin: 10,
                autoHeight: true,
                //slideSpeed: 5000,
                nav: true,
                autoplay: false,
                dots: false,
                loop: true,
                lazyFollow: true,
                lazyLoad: true,
                animateIn: 'fadeIn',
                //animateOut: 'fadeOut',
                responsiveRefreshRate: 200,
                navText: ['<svg width="100%" height="100%" viewBox="0 0 11 20" aria-hidden="true"><path style="fill:none;stroke-width: 1px;stroke: #000;" d="M9.554,1.001l-8.607,8.607l8.607,8.606"/></svg>', '<svg width="100%" height="100%" viewBox="0 0 11 20" version="1.1" aria-label="下一張圖片"><path style="fill:none;stroke-width: 1px;stroke: #000;" d="M1.054,18.214l8.606,-8.606l-8.606,-8.607"/></svg>'],
            }).on('changed.owl.carousel', syncPosition);

            sync2.on('initialized.owl.carousel', function () {
                sync2.find(".owl-item").eq(0).addClass("current");
            })
                .owlCarousel({
                    items: slidesPerPage,
                    dots: false,
                    nav: false,
                    smartSpeed: 100,
                    lazyFollow: true,
                    lazyLoad: true,
                    slideSpeed: 500,
                    slideBy: slidesPerPage, //alternatively you can slide by 1, this way the active slide will stick to the first item in the second carousel
                    responsiveRefreshRate: 100
                }).on('changed.owl.carousel', syncPosition2);

            function syncPosition(el) {
                //if you set loop to false, you have to restore this next line
                //var current = el.item.index;

                //if you disable loop you have to comment this block
                var count = el.item.count - 1;
                var current = Math.round(el.item.index - (el.item.count / 2) - .5);

                if (current < 0) {
                    current = count;
                }
                if (current > count) {
                    current = 0;
                }

                //end block

                sync2
                    .find(".owl-item")
                    .removeClass("current")
                    .eq(current)
                    .addClass("current");
                var onscreen = sync2.find('.owl-item.active').length - 1;
                var start = sync2.find('.owl-item.active').first().index();
                var end = sync2.find('.owl-item.active').last().index();

                if (current > end) {
                    sync2.data('owl.carousel').to(current, 100, true);
                }
                if (current < start) {
                    sync2.data('owl.carousel').to(current - onscreen, 100, true);
                }
            }

            function syncPosition2(el) {
                if (syncedSecondary) {
                    var number = el.item.index;
                    sync1.data('owl.carousel').to(number, 100, true);
                }
            }

            sync2.on("click", ".owl-item", function (e) {
                e.preventDefault();
                var number = $(this).index();
                sync1.data('owl.carousel').to(number, 0, true);
            });
        });

    </script>
    <style type="text/css">
        
    </style>

</asp:Content>
