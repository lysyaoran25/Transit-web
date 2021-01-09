var UITree = function () {
    return {
        init: function () {
            var $treeview = $('.jstreeview');
            if ($treeview.data('checkbox') != undefined)
                $treeview.jstree({
                    "core": {
                        "themes": { "variant": "large", "icons": false },
                        "multiple": true,
                    },
                    "checkbox": {
                        "keep_selected_style": true
                    },
                    "plugins": ["checkbox"]
                });
            else
                $treeview.jstree({
                    "core": {
                        "themes": { "variant": "large", "icons": false },
                        "multiple": true,
                    }
                });
            //Action change index tree view
            //$treeview.on('changed.jstree', function (e, data) {
            //    var i, j, r = [];
            //    for (i = 0, j = data.selected.length; i < j; i++) {
            //        //if (data.selected[i] == '' || data.selected[i] == null) return false;
            //        //else {
            //        //    var check = $("#" + data.selected[i]).find('.checker').find('span');
            //        //    if (check.hasClass('checked')) {
            //        //        check.removeClass('checked');
            //        //    }else {
            //        //        check.addClass('checked');
            //        //    }
            //        //}
            //    }
            //})
            // create the instance
            //.jstree();
            $treeview.jstree("open_all");
        },
        Close_Tree: function () {
            try {
                var $treeview = $('.jstreeview');
                $treeview.jstree("close_all");
            }
            catch (e) {
                console.log('Lỗi javascript: ' + e);
            }
        },
        Open_Tree: function () {
            try {
                var $treeview = $('.jstreeview');
                $treeview.jstree("open_all");
            }
            catch (e) {
                console.log('Lỗi javascript: ' + e);
            }
        },
    };
}();

var UITree1 = function () {
    return {
        init: function () {
            var $treeview = $('.jstreeview1');
            if ($treeview.data('checkbox') != undefined)
                $treeview.jstree({
                    "core": {
                        "themes": { "variant": "large", "icons": false },
                        "multiple": true,
                    },
                    "checkbox": {
                        "keep_selected_style": true
                    },
                    "plugins": ["checkbox"]
                });
            else
                $treeview.jstree({
                    "core": {
                        "themes": { "variant": "large", "icons": false },
                        "multiple": true,
                    }
                });
            //Action change index tree view
            //$treeview.on('changed.jstree', function (e, data) {
            //    var i, j, r = [];
            //    for (i = 0, j = data.selected.length; i < j; i++) {
            //        //if (data.selected[i] == '' || data.selected[i] == null) return false;
            //        //else {
            //        //    var check = $("#" + data.selected[i]).find('.checker').find('span');
            //        //    if (check.hasClass('checked')) {
            //        //        check.removeClass('checked');
            //        //    }else {
            //        //        check.addClass('checked');
            //        //    }
            //        //}
            //    }
            //})
            // create the instance
            //.jstree();
            $treeview.jstree("open_all");
        },
        Close_Tree: function () {
            try {
                var $treeview = $('.jstreeview1');
                $treeview.jstree("close_all");
            }
            catch (e) {
                console.log('Lỗi javascript: ' + e);
            }
        },
        Open_Tree: function () {
            try {
                var $treeview = $('.jstreeview1');
                $treeview.jstree("open_all");
            }
            catch (e) {
                console.log('Lỗi javascript: ' + e);
            }
        },
    };
}();