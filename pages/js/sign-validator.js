!function ($) {

    var Focus = function () {
        function Focus(elemt_str, validator) {
            (typeof elemt_str == 'string') ? this.element = document.getElementById(elemt_str) : this.element = null;
            (typeof validator == 'string') ? this.validator = validator : this.validator = null;
        }

        Focus.prototype.addFocus = function (cliked) {
            //if (cliked) {
            //    return;
            //}

            var ele = this.element;
            var val = this.validator;

            if (!ele) {
                return;
            }

            ele.addEventListener('focus', function () {
                var validatorName = this.parentElement.getElementsByClassName(val);

                for (var i = 0, length = validatorName.length; i < length; i++) {
                    validatorName[i].style.visibility = 'hidden';
                };

                //toALL(validatorName, 'visibility');

                //this.parentElement.style.boxShadow = 'inset 0 1px 2px rgba(27,31,35,0.075)';

                //clicked = !clicked;

            }, false);
        };

        //var toAll = function (e, a) {
        //    for (var i = 0, length = e.length; i < length; i++) {
        //        //if (clicked)
        //            e[i].style[a] = 'hidden';
        //        //else
        //        //    e[i].style[a] = 'visible';
        //    };
        //}

        //FocusEvent.prototype.removeFocus = function () {
        //};

        return Focus;
    }();

    //var ClickEvent = function () {
    //}();

    var clicked = false;

    //document.getElementsByClassName('sign')[0].addEventListener('click', function () {
    //    clicked = !clicked;
    //    if(clicked)
    //        document.getElementsByClassName('validator')[0].style.visibility = '';
    //}, false);

     (new Focus('nameBox',          'validator')).addFocus(clicked);
     (new Focus('emailBox',         'validator')).addFocus(clicked);
     (new Focus('phoneBox',         'validator')).addFocus(clicked);
     (new Focus('passwdBox',        'validator')).addFocus(clicked);
     (new Focus('confirmPasswdBox', 'validator')).addFocus(clicked);

}(window);