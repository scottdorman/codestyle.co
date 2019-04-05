/*!
 * jQuery goTop v1.1.2 (https://github.com/scottdorman/jquery-gotop)
 * Copyright 2015 Scott Dorman (@sdorman)
 * Licensed under MIT (https://github.com/scottdorman/jquery-gotop/blob/master/LICENSE)
 * Adapted from goUp originally developed by Roger Vila (@_rogervila)
 */
(function ($) {
    $.fn.goTop = function (options) {

        $.fn.goTop.defaults = {
            appear: 200,
            scrolltime: 800,
            src: "glyphicon glyphicon-chevron-up",
            width: 45,
            place: "right",
            fadein: 500,
            fadeout: 500,
            opacity: 0.5,
            marginX: 2,
            marginY: 2
        };

        var opts = $.extend({}, $.fn.goTop.defaults, options);

        return this.each(function () {
            var g = $(this);
            g.html("<a id='goTopAnchor'><span id='goTopSpan' /></a>");

            var ga = g.children('a');
            var gs = ga.children('span');

            var css = {
                "position": "fixed",
                "display": "block",
                "width": "'" + opts.width + "px'",
                "z-index": "9",
                "bottom": opts.marginY + "%"
            };

            css[opts.place === "left" ? "left" : "right"] = opts.marginX + "%";

            g.css(css);

            //opacity
            ga.css("opacity", opts.opacity);
            gs.addClass(opts.src);
            gs.css("font-size", opts.width);
            gs.hide();

            //appear, fadein, fadeout
            $(function () {
                $(window).scroll(function () {
                    if ($(this).scrollTop() > opts.appear) {
                        gs.fadeIn(opts.fadein);
                    }
                    else {
                        gs.fadeOut(opts.fadeout);
                    }
                });

                //hover effect
                $(ga).hover(function () {
                    $(this).css("opacity", "1.0");
                    $(this).css("cursor", "pointer");
                }, function () {
                    $(this).css("opacity", opts.opacity);
                });

                //scrolltime
                $(ga).click(function () {
                    $('body,html').animate({
                        scrollTop: 0
                    }, opts.scrolltime);
                    return false;
                });
            });
        });
    };
})(jQuery);
