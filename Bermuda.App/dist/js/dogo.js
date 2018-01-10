/*!
* dogo.js 1.0.0-alpha.1
* @author Bermuda Team
*/
'use strict';

var _get = function get(_x, _x2, _x3) { var _again = true; _function: while (_again) { var object = _x, property = _x2, receiver = _x3; _again = false; if (object === null) object = Function.prototype; var desc = Object.getOwnPropertyDescriptor(object, property); if (desc === undefined) { var parent = Object.getPrototypeOf(object); if (parent === null) { return undefined; } else { _x = parent; _x2 = property; _x3 = receiver; _again = true; desc = parent = undefined; continue _function; } } else if ('value' in desc) { return desc.value; } else { var getter = desc.get; if (getter === undefined) { return undefined; } return getter.call(receiver); } } };

var _createClass = (function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ('value' in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; })();

function _inherits(subClass, superClass) { if (typeof superClass !== 'function' && superClass !== null) { throw new TypeError('Super expression must either be null or a function, not ' + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError('Cannot call a class as a function'); } }

!(function ($) {

    console.log('Welcome to visit Bermuda website!');

    /**
     * @desc 卡片滚动
     */
    var showCardSlide = function showCardSlide() {
        var caro = document.querySelector('.caro-slider');

        if (!caro) {
            return;
        }

        var item = caro.querySelectorAll('.item');
        var slideSize = item[0].offsetWidth + 14;
        var count = item.lengt - 7; // 设置滑动的次数

        var i = 0;
        var transX = slideSize; // 向左

        var timer = $.setInterval(function () {

            var left = -Math.pow(-1, i / count ^ 0); // 指数取整

            if (left > 0) {
                if (i % count == 0) {
                    transX = 0;
                }
            }

            caro.style.transform = 'translateX(-' + transX + 'px)';

            transX += slideSize;
            i++;
        }, 2000);
    };

    /**
     * @desc 显示下拉菜单
     * @author _king
     */
    var showDropMenu = function showDropMenu() {
        var userProfile = document.getElementsByClassName('user-profile')[0];

        if (!userProfile) {
            return;
        }

        var avatar = userProfile.getElementsByClassName('user-avatar')[0];
        var profile = userProfile.getElementsByClassName('profile')[0];

        userProfile.addEventListener('mouseover', function () {
            profile.style.visibility = 'visible';
            profile.style.opacity = '1';
        }, false);

        userProfile.addEventListener('mouseout', function () {
            profile.style.opacity = '0';
            profile.style.visibility = 'hidden';
        }, false);
    };

    /**
     * @desc 显示提示信息
     * @author _king
     */
    var showPromptInfo = function showPromptInfo() {
        var prompt = document.getElementsByClassName('prompt')[0];
        //const promptInfo = prompt.getElementsByTagName('span')[0];

        if (!prompt) {
            return;
        }

        if (prompt.innerText) {
            (function () {

                prompt.style.opacity = 0.6;

                //console.log(signprompt);

                // 用计时器控制提示信息 5s 后消失
                var timer = setTimeout(function () {
                    prompt.style.opacity = 0;
                    clearTimeout(timer);
                }, 5000);
            })();
        }
    };

    /**
     * @desc 显示验证信息
     * @author _king
     */
    var showValitorInfo = function showValitorInfo() {
        var signBody = document.getElementsByClassName('sign-body')[0];

        if (!signBody) {
            return;
        }

        var signInput = signBody.getElementsByClassName('sign-input')[0];
        var signBtn = signBody.getElementsByClassName('sign-btn')[0];

        // 为登录或注册按钮添加点击事件
        signBtn.addEventListener('click', function () {
            var validator = signInput.getElementsByClassName('validator');

            var _loop = function (i, _length) {
                var timer = setTimeout(function () {
                    validator[i].style.opacity = 1;
                    clearTimeout(timer);
                }, 0);
            };

            for (var i = 0, _length = validator.length; i < _length; i++) {
                _loop(i, _length);
            }
        }, false);

        var inputItem = signInput.getElementsByClassName('item');

        var _loop2 = function (i, _length2) {

            var input = inputItem[i].getElementsByTagName('input')[0];

            // 为每个输入框添加键盘按下事件
            input.addEventListener("keydown", function (event) {

                //if (event.key.length === 1 && /\w/.test(event.key)) { // 匹配字母、数字、下划线

                var validator = inputItem[i].getElementsByClassName('validator'); // 每个输入框的所有验证控件

                var _loop3 = function (j, len) {
                    var timer = setTimeout(function () {
                        validator[j].style.opacity = 0;
                        clearTimeout(timer);
                    }, 0);
                };

                for (var j = 0, len = validator.length; j < len; j++) {
                    _loop3(j, len);
                }
            }, false);
        };

        for (var i = 0, _length2 = inputItem.length; i < _length2; i++) {
            _loop2(i, _length2);
        }
    };

    /**
     * @desc 上传图片的预览
     * @author _king
     */
    var uploadImgPreview = function uploadImgPreview() {
        var uploadInput = document.getElementsByClassName('upload-input')[0];

        if (!uploadInput) {
            return;
        }

        uploadInput.addEventListener('change', function () {
            var reader = undefined;
            var iconUploadImg = document.getElementsByClassName('icon-upload-img')[0];

            // 判断是否支持FileReader
            if (window.FileReader) {
                reader = new FileReader();
            } else {
                $.alert("Your device does not support picture preview, please upgrade your device if you need this feature！");
            }

            // 获取文件
            var file = uploadInput.files[0];
            var imageType = /^image\//;

            // 是否是图片
            if (!imageType.test(file.type)) {
                alert("Please select a image！");
                return;
            }

            // 读取完成
            reader.onload = function (e) {

                // 图片路径设置为读取的图片
                var uploadImg = document.getElementsByClassName('upload-img')[0];
                var frag = document.createDocumentFragment();

                var preview = uploadImg.getElementsByClassName('preview');
                console.log(preview);

                if (preview.length != 0) {
                    preview[0].src = e.target.result;
                    return;
                }

                var img = document.createElement('img');
                img.className = 'preview';
                img.src = e.target.result;

                frag.appendChild(img);

                uploadImg.appendChild(frag);
            };

            reader.readAsDataURL(file);

            iconUploadImg.classList.add('hidden');
        }, false);
    };

    /**
     * @desc 显示话题创建面板
     * @author _king
     */
    var showTopicEdit = function showTopicEdit() {
        var linkTopicEdit = $get('.create-topic')[0];
        var topicEdit = $get('.topic-edit-container')[0];

        if (!topicEdit || !linkTopicEdit) {
            return;
        }

        linkTopicEdit.addEventListener('click', function () {
            topicEdit.style.display = 'flex';

            var timer = $.setTimeout(function () {
                topicEdit.style.opacity = '1';
                $.clearTimeout(timer);
            }, 0);
        }, false);

        var close = topicEdit.getElementsByClassName('icon-close')[0];

        close.addEventListener('click', function (event) {

            topicEdit.style.opacity = '0';

            var timer = $.setTimeout(function () {
                topicEdit.style.display = 'none';
                $.clearTimeout(timer);
            }, 300); // 0.3s 后执行
        }, false);
    };

    /**
     * @desc 删除菜单栏的高亮效果
     * @author _king
     */
    var removeActiveClass = function removeActiveClass() {
        // 判断是否为主页
        if ($.location.pathname !== "/Home.aspx" && $.location.pathname !== '/') {
            var menu = document.getElementsByClassName('menu')[0];

            if (!menu) {
                return;
            }

            var active = menu.getElementsByClassName('active')[0];

            active.classList.remove('active');
        }
    };

    /**
     * @desc 显示回复发布区域
     * @author _king
     */
    var showPubReplyArea = function showPubReplyArea() {
        var cmnt = document.getElementsByClassName('comment')[0];

        if (!cmnt) {
            return;
        }

        var item = cmnt.getElementsByClassName('item');

        // TODO: 待优化

        var _loop4 = function (i, len) {
            var meta = item[i].getElementsByClassName('meta');
            var hidden = item[i].getElementsByClassName('hidden')[0];
            var cmntReply = item[i].getElementsByClassName('cmnt-reply')[0];

            if (!cmntReply) {
                return {
                    v: undefined
                };
            }

            var aimsUser = cmntReply.getElementsByClassName('aims-user');
            var aimsUserArr = [];

            for (var j = 0, leng = aimsUser.length; j < leng; j++) {
                if (aimsUser[j].innerText.length === 0) {
                    // 找出无回复目标的用户链接
                    aimsUserArr.push(j);
                }
            }

            var _len = aimsUser.length;
            var _count = 0;

            aimsUserArr.forEach(function (item) {

                // 删除无回复目标的用户链接
                //
                // 注意：aimsUser 删除 1 个节点，长度减 1
                //

                item = item - _count; // 设置删除节点的索引

                aimsUser[item].parentNode.removeChild(aimsUser[item]);

                _count++;

                // cmntReply.removeChild(aimsUser[item]);
            });

            // 遍历元件区域，为回复按钮添加点击事件
            //

            var _loop5 = function (j, leng) {
                var reply = meta[j].getElementsByClassName('reply')[0];

                // 为评论回复的回复按钮添加点击事件
                //
                reply.addEventListener('click', function () {

                    var isLogin = isSignIn();

                    if (!isLogin) {
                        rediret("/layout/SignIn.aspx"); // 未登录时，跳转到登录页
                        return;
                    }

                    hidden.classList.remove('hidden'); // 显现回复框

                    var name = meta[j].parentElement.getElementsByClassName('name')[0]; // 获取评论对象的名字
                    var textarea = hidden.getElementsByTagName('textarea')[0];
                    var aimsId = reply.getAttribute('data-aims-id');

                    textarea.value = ''; // 清空输入框

                    // 设置回复目标 ID
                    if (aimsId) {
                        var hdnAimsId = hidden.getElementsByTagName('input')[0];
                        hdnAimsId.value = aimsId;
                    }

                    // 为回复框设置 placeholder
                    // e.g. `@test`
                    var placeHolderStr = name ? '@' + name.innerText : '写下你的回复（140 字以内）';

                    textarea.setAttribute('placeholder', placeHolderStr);

                    textarea.focus(); // 聚焦

                    // 计时器 0s 后回调设置模糊度为 1
                    var timer = setTimeout(function () {
                        hidden.style.opacity = '1';
                        clearTimeout(timer);
                    }, 0);

                    var cancel = hidden.getElementsByClassName('cancel')[0]; // 取消按钮
                    var pubBtn = hidden.getElementsByClassName('reply-btn')[0].getElementsByTagName('input')[0]; // 回复按钮

                    // console.log(pubBtn);

                    // 为取消按钮添加点击事件
                    cancel.addEventListener('click', function () {
                        hidden.style.opacity = '0';

                        var timer = setTimeout(function () {
                            hidden.classList.add('hidden');
                            clearTimeout(timer);
                        }, 300); // 0.3s 后设置 hidden 的 display 为 none
                    }, false);

                    // 点击回复按钮时，隐藏回复区域
                    pubBtn.addEventListener('click', function () {
                        hidden.classList.add('hidden');
                    }, false);
                }, false);
            };

            for (var j = 0, leng = meta.length; j < leng; j++) {
                _loop5(j, leng);
            }
        };

        for (var i = 0, len = item.length; i < len; i++) {
            var _ret5 = _loop4(i, len);

            if (typeof _ret5 === 'object') return _ret5.v;
        }
    };

    /**
     * @desc 跳转页面
     * @param {string} url 跳转页的地址
     * @author _king
     */
    var rediret = function rediret(url) {
        $.location.href = url;
    };

    /**
     * @desc 动画 - 粒子动画, 应用于登录注册页
     * @author Hnsn Wu
     */
    var showCanvasAnimation = function showCanvasAnimation() {

        // 圆形

        var Circle = (function () {
            function Circle(x, y) {
                _classCallCheck(this, Circle);

                this.x = x;
                this.y = y;
                this.r = Math.random() * 14 + 1;
                this._mx = Math.random() * 2 - 1;
                this._my = Math.random() * 2 - 1;
            }

            _createClass(Circle, [{
                key: 'drawCircle',
                value: function drawCircle(ctx) {
                    ctx.beginPath();
                    ctx.arc(this.x, this.y, this.r, 0, 360);
                    ctx.closePath();
                    ctx.fillStyle = '#fdebeb';
                    ctx.fill();
                }
            }, {
                key: 'drawLine',
                value: function drawLine(ctx, _circle) {
                    var dx = this.x - _circle.x;
                    var dy = this.y - _circle.y;
                    var d = Math.sqrt(dx * dx + dy * dy);
                    if (d < 150) {
                        ctx.beginPath();
                        ctx.moveTo(this.x, this.y); //起始点 
                        ctx.lineTo(_circle.x, _circle.y); //终点 
                        ctx.closePath();
                        ctx.strokeStyle = '#fdebeb';
                        ctx.stroke();
                    }
                }
            }, {
                key: 'move',
                value: function move(w, h) {
                    this._mx = this.x < w && this.x > 0 ? this._mx : -this._mx;
                    this._my = this.y < h && this.y > 0 ? this._my : -this._my;
                    this.x += this._mx / 2;
                    this.y += this._my / 2;
                }
            }]);

            return Circle;
        })();

        var currentCircle = (function (_Circle) {
            _inherits(currentCircle, _Circle);

            function currentCircle(x, y) {
                _classCallCheck(this, currentCircle);

                _get(Object.getPrototypeOf(currentCircle.prototype), 'constructor', this).call(this, x, y);
            }

            // This `$` is `window` object!
            //

            return currentCircle;
        })(Circle);

        $.requestAnimationFrame = $.requestAnimationFrame || $.mozRequestAnimationFrame || $.webkitRequestAnimationFrame || $.msRequestAnimationFrame;

        var canvas = document.querySelector("#canvas");

        if (!canvas) {
            return;
        }

        var ctx = canvas.getContext("2d");
        var w = canvas.width = canvas.offsetWidth;
        var h = canvas.height = canvas.offsetHeight;
        var circles = [];
        var current_circle = new currentCircle(0, 0);

        var draw = function draw() {
            ctx.clearRect(0, 0, w, h);
            for (var i = 0; i < circles.length; i++) {
                circles[i].move(w, h);
                circles[i].drawCircle(ctx);

                for (var j = i + 1; j < circles.length; j++) {
                    circles[i].drawLine(ctx, circles[j]);
                }
            }

            if (current_circle.x) {
                current_circle.drawCircle(ctx);

                for (var k = 1; k < circles.length; k++) {
                    current_circle.drawLine(ctx, circles[k]);
                }
            }

            requestAnimationFrame(draw);
        };

        var init = function init(num) {
            for (var i = 0; i < num; i++) {
                circles.push(new Circle(Math.random() * w, Math.random() * h));
            }
            draw();
        };

        $.addEventListener('load', init(80));

        $.onmousemove = function (e) {
            e = e || window.event;
            current_circle.x = e.clientX;
            current_circle.y = e.clientY;
        }, $.onmouseout = function () {
            current_circle.x = null;
            current_circle.y = null;
        };
    };

    /**
     * @desc 放大图片 - 应用于启示详情页
     * @author Hnsn Wu
     */
    var zoomGoodsImg = function zoomGoodsImg() {
        var zoomContainer = document.getElementById('zoom-container');

        if (!zoomContainer) {
            return;
        }

        var moimg = zoomContainer.getElementsByClassName('zoom-img')[0];
        var goodsImg = zoomContainer.parentElement.getElementsByClassName('goods-img')[0];
        var caption = zoomContainer.getElementsByClassName('caption')[0];
        var close = zoomContainer.getElementsByClassName("close")[0];

        // 物品图片添加点击事件
        goodsImg.addEventListener('click', function () {
            zoomContainer.style.display = 'block';
            moimg.src = goodsImg.src;
            caption.innerHTML = goodsImg.alt;
        }, false);

        // 点击关闭放大图片
        close.addEventListener('click', function () {
            zoomContainer.style.display = 'none';
        }, false);
    };

    /**
     * @desc 重设图片大小 - 应用于首页
     * @author _king
     */
    var resetImgSize = function resetImgSize() {
        // TODO:
    };

    /**
     * @desc 在非首页显示登录链接
     * @author _king
     */
    var showSignInLink = function showSignInLink() {
        var linkSignIn = document.getElementsByClassName('link-signin')[0];

        if (!linkSignIn) {
            return;
        }

        // 通过 cookie 判断用户是否登录
        // let isSignIn = getCookie('IsSignIn');  // TODO: 此处代完善

        var isLogin = isSignIn();

        if ($.location.pathname !== '/Home.aspx' && $.location.pathname !== '/' && isLogin !== true) {
            linkSignIn.style.display = 'block';
        }
    };

    /**
     * @desc 通过判断 UserProfile 元素是否存在来判断用户是否登录
     * @author _king
     * @returns {Bool}
     */
    var isSignIn = function isSignIn() {
        var userProfile = document.getElementById('UserProfile');

        return !userProfile ? false : true;
    };

    /**
     * @desc 根据 name 读取 cookie
     * @param  {String} name 
     * @return {String} cookie 值
     * @author _king
     */
    var getCookie = function getCookie(name) {
        var arr = document.cookie.replace(/\s/g, '').split(';');

        for (var i = 0, len = arr.length; i < len; i++) {
            var tempArr = arr[i].split('=');

            if (tempArr[0] == name) {
                return decodeURIComponent(tempArr[1]);
            }
        }
        return '';
    };

    /*
     * @desc 给 tablist 的项添加点击出现下划线的效果
     * @author _king
     */
    var showUnderlineForTablist = function showUnderlineForTablist() {
        var tablist = document.getElementsByClassName('tablist');

        if (!tablist || tablist.length == 0) {
            return;
        }

        var tablistArr = Array.prototype.slice.call(tablist, 0); // 将 DOM 元素转化成数组

        tablistArr.forEach(function (item) {
            item.addEventListener('click', function (event) {
                var target = event.target || event.srcElement;
                var tagName = target.tagName.toLowerCase();
                var active = item.querySelector('.active');
                var activeBtn = item.querySelector('.active-btn');

                // 判断元素是 a 或 span 标签
                if (/a/.test(tagName)) {

                    if (active) {
                        active.classList.remove('active');
                    }

                    target = tagName === 'a' ? target : target.parentElement; // <a> or <span>
                    target.classList.add('active');

                    // let list = document.querySelector('.left-list');
                    // list.setAttribute('active-control', 'test');
                    // console.log(list);
                } else if (/input/.test(tagName)) {
                        if (activeBtn) {
                            activeBtn.classList.remove('active-btn');
                        }

                        target.classList.add('active-btn');
                    }
            }, false);
        });
    };

    /**
     * @desc DOM 元素属性设置
     * @param {object} dom 页面 DOM 元素
     * @param {object} json JSON 格式的键值对 
     * @returns {object} DOM 元素
     */
    var attr = function attr(dom, json) {

        if (typeof dom != 'object' || typeof json !== 'object') {
            return;
        }

        for (var key in json) {
            if (json.hasOwnProperty(key)) {
                var value = json[key];
                dom.setAttribute(key, value);
            }
        }

        return dom;
    };

    /**
     * @desc 获取页面的 DOM 元素
     * @param {string} idClassTagStr DOM 元素的 ID 或 class 或 tag 选择器
     * @returns {object} DOM 元素组
     * @author _king
     */
    var $get = function $get(idClassTagStr) {

        if (idClassTagStr.startsWith('.')) {
            return document.getElementsByClassName(idClassTagStr.substr(1)); // class
        } else if (idClassTagStr.startsWith('#')) {
                return document.getElementById(idClassTagStr.substr(1)); // id
            } else {
                    return document.getElementsByTagName(idClassTagStr); // tag name
                }
    };

    /**
     * @desc 将 DOM 元素转换成 数组
     * @param {object} dom DOM 元素
     * @returns {object} DOM 元素数组
     * @author _king
     */
    var domToArray = function domToArray(dom) {
        return typeof dom === 'object' ? Array.prototype.slice.call(dom) : null;
    };

    /*
     * @desc 创建一个 DOM 元素
     * @param {string} tag 标签名
     * @returns {object} DOM 元素
     * @author _king
     */
    var $newtag = function $newtag(tag) {
        return document.createElement(tag);
    };

    /**
     * @desc 显示搜索话题的 Div - 应用与动态发布页，点击发表按钮时触发
     * @author _king
     */
    var showSearchTopicDiv = function showSearchTopicDiv() {

        var pubCurrentBtn = $get('#pub-current-btn');

        if (!pubCurrentBtn) {
            return;
        }

        var selectTopic = $get('.select-topic')[0];
        var cancelBtn = $get('.cancel-btn')[0]; // 取消按钮

        pubCurrentBtn.addEventListener('click', function () {
            selectTopic.style.opacity = '1';
            pubCurrentBtn.classList.add('clicked');
        }, false);

        cancelBtn.addEventListener('click', function () {
            selectTopic.style.opacity = '0';
            pubCurrentBtn.classList.remove('clicked');

            //let timer = $.setTimeout(() => {
            //    pubCurrentBtn.classList.remove('clicked');
            //    $.clearTimeout(timer);
            //}, 300);
        });
    };

    /*
     * @desc 简单搜索话题项 - 应用于动态发布页
     * @author _king
     */
    var searchTopicItem = function searchTopicItem() {
        var searchItems = $get('.search-items')[0];

        if (!searchItems) {
            return;
        }

        var selector = $get('#LbTopic');
        var selectorFrag = document.createDocumentFragment();
        var selectorDiv = $newtag('div');
        var optionUl = $newtag('ul');

        // 属性的设置

        attr(selectorDiv, {
            'class': 'multiple-search-selector'
        });

        attr(optionUl, {
            'class': 'options'
        });

        selectorDiv.appendChild(optionUl); // ul -> div

        // 移植搜索项

        var selectorArr = domToArray(selector); // DOM 转数组

        selectorArr.forEach(function (option) {

            if (!option.disabled) {
                var li = $newtag('li');

                attr(li, {
                    'class': 'item',
                    'data-index': option.index,
                    'data-value': option.value,
                    'selected': false
                }).textContent = option.textContent;

                optionUl.appendChild(li); // li -> ul
            }
        });

        var selectedItems = $get('.selected-items')[0];
        var selectedItemsFrag = document.createDocumentFragment(); // 保存选中项

        // 添加点击事件
        optionUl.addEventListener('click', function (event) {
            var target = event.target || event.srcElement;

            if (selectedItems.childNodes.length == 3) {
                return;
            }

            // 选中项
            if (target.classList.contains('item')) {
                (function () {
                    var index = target.getAttribute('data-index'); // 获取选中项的索引

                    selector.options[index].selected = true; // 为真实的下拉框设置选中项
                    attr(target, { 'selected': true }); // 已选项下次匹配不显示

                    if (target.classList.contains('active')) {
                        target.classList.remove('active');
                    }

                    // 添加选中项
                    var selectedItemSpan = $newtag('span');
                    var iconDelete = $newtag('i');

                    attr(selectedItemSpan, {
                        'class': 'item',
                        'data-selected-index': index
                    }).textContent = target.textContent;

                    attr(iconDelete, {
                        'class': 'icon-delete'
                    }).addEventListener('click', function () {

                        selector.options[index].selected = false;
                        attr(target, { 'selected': false });

                        selectedItemSpan.parentElement.removeChild(selectedItemSpan);
                    }, false);

                    selectedItemSpan.appendChild(iconDelete); // i -> span

                    selectedItemsFrag.appendChild(selectedItemSpan); // span -> frag
                    selectedItems.appendChild(selectedItemsFrag); // frag -> selected items div
                })();
            }
        }, false);

        selectorFrag.appendChild(selectorDiv); // div -> frag
        selector.parentElement.appendChild(selectorFrag); // frag -> select parent

        // 开始搜索 - 简易的搜索

        var searchTopicInput = $get('#SearchTopic'); // 搜索框

        searchTopicInput.addEventListener('keyup', function () {
            var value = searchTopicInput.value;
            var items = optionUl.getElementsByClassName('item');

            for (var i = 0, _length3 = items.length; i < _length3; i++) {

                // 匹配字符串， 除空字符串、已选项
                if (items[i].textContent.includes(value) && value && items[i].getAttribute('selected') == 'false') {

                    items[i].classList.add('active');
                } else {
                    items[i].classList.remove('active');
                }
            }
        });
    };

    // 调用模块
    showCardSlide();
    showDropMenu();
    showPromptInfo();
    showValitorInfo();
    uploadImgPreview();
    showTopicEdit();
    removeActiveClass();
    showPubReplyArea();
    showCanvasAnimation();
    zoomGoodsImg();
    showSignInLink();
    showUnderlineForTablist();
    searchTopicItem();
    showSearchTopicDiv();
})(window);

