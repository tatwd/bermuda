/*!
 * dogo.js 1.0.0-alpha.1
 * @author Bermuda Team
 */
!function ($) {

    console.log('Welcome to visit Bermuda website!');

    /**
     * @desc 卡片滚动
     */
    let showCardSlide = () => {
        const caro = document.querySelector('.caro-slider');

        if (!caro) {
            return;
        }

        const item      = caro.querySelectorAll('.item');
        const slideSize = item[0].offsetWidth ;

        const count = item.length - 7; // 设置滑动的次数
        
        let i      = 0;
        let left   = 0; // < 0 向左
        let transX = 0;

        let timer = $.setInterval(() => {

            left = -Math.pow(-1, (i / count) ^ 0); // 指数取整

            transX = left < 0
                ? transX - slideSize
                : transX + slideSize;

            caro.style.transform = `translateX(${transX}px)`;

            i++;
        }, 2000);

    };

    /**
     * @desc 显示下拉菜单
     * @author _king
     */
    let showDropMenu = () => {
        const userProfile = document.getElementsByClassName('user-profile')[0];

        if (!userProfile) {
            return;
        }
        
        const avatar  = userProfile.getElementsByClassName('user-avatar')[0];
        const profile = userProfile.getElementsByClassName('profile')[0];

        userProfile.addEventListener('mouseover', () => {
            profile.style.visibility = 'visible';
            profile.style.opacity = '1';
        }, false);

        userProfile.addEventListener('mouseout', () => {
            profile.style.opacity = '0';
            profile.style.visibility = 'hidden';
        }, false);

    };

    /**
     * @desc 显示提示信息
     * @author _king
     */
    let showPromptInfo = () => {
        const prompt = document.getElementsByClassName('prompt')[0];
        //const promptInfo = prompt.getElementsByTagName('span')[0];

        if (!prompt) {
            return;
        }


        if (prompt.innerText) {

            prompt.style.opacity = 0.6;

            //console.log(signprompt);

            // 用计时器控制提示信息 5s 后消失
            let timer = setTimeout(() => {
                prompt.style.opacity = 0;
                clearTimeout(timer);
            }, 5000);
        }
    };

    /**
     * @desc 显示验证信息
     * @author _king
     */
    let showValitorInfo = () => {
        const signBody = document.getElementsByClassName('sign-body')[0];

        if (!signBody) {
            return;
        }

        let signInput = signBody.getElementsByClassName('sign-input')[0];
        let signBtn   = signBody.getElementsByClassName('sign-btn')[0];

        // 为登录或注册按钮添加点击事件
        signBtn.addEventListener('click', () => {
            let validator = signInput.getElementsByClassName('validator');

            for (let i = 0, length = validator.length; i < length; i++) {
                let timer = setTimeout(() => {
                    validator[i].style.opacity = 1;
                    clearTimeout(timer);
                }, 0);
            }
        }, false);

        let inputItem = signInput.getElementsByClassName('item');

        for (let i = 0, length = inputItem.length; i < length; i++) {

            let input = inputItem[i].getElementsByTagName('input')[0];

            // 为每个输入框添加键盘按下事件
            input.addEventListener("keydown", (event) => {

                //if (event.key.length === 1 && /\w/.test(event.key)) { // 匹配字母、数字、下划线

                let validator = inputItem[i].getElementsByClassName('validator'); // 每个输入框的所有验证控件

                for (let j = 0, len = validator.length; j < len; j++) {
                    let timer = setTimeout(() => {
                        validator[j].style.opacity = 0;
                        clearTimeout(timer);
                    }, 0);
                }
            }, false);
        }

    };

    /**
     * @desc 上传图片的预览
     * @author _king
     */
    let uploadImgPreview = () => {
        let uploadInput = document.getElementsByClassName('upload-input')[0];

        if (!uploadInput) {
            return;
        }

        uploadInput.addEventListener('change', () => {
            let reader;
            let iconUploadImg = document.getElementsByClassName('icon-upload-img')[0];
            
            // 判断是否支持FileReader
            if (window.FileReader) {
                reader = new FileReader();
            } else {
                $.alert("Your device does not support picture preview, please upgrade your device if you need this feature！");
            }

            // 获取文件
            let file      = uploadInput.files[0];
            let imageType = /^image\//;

            // 是否是图片
            if (!imageType.test(file.type)) {
                alert("Please select a image！");
                return;
            }

            // 读取完成
            reader.onload = function (e) {

                // 图片路径设置为读取的图片
                let uploadImg = document.getElementsByClassName('upload-img')[0];
                let frag      = document.createDocumentFragment();

                let preview = uploadImg.getElementsByClassName('preview');
                console.log(preview);

                if (preview.length != 0) {
                    preview[0].src = e.target.result;
                    return;
                }

                let img = document.createElement('img');
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
    let showTopicEdit = () => {
        let linkTopicEdit = $get('.create-topic')[0];
        let topicEdit = $get('.topic-edit-container')[0];

        if (!topicEdit || !linkTopicEdit) {
            return;
        }

        linkTopicEdit.addEventListener('click', () => {
            topicEdit.style.display = 'flex';

            let timer = $.setTimeout(() => {
                topicEdit.style.opacity = '1';
                $.clearTimeout(timer);
            }, 0);

        }, false);

        let close = topicEdit.getElementsByClassName('icon-close')[0];

        close.addEventListener('click', event => {

            topicEdit.style.opacity = '0';

            let timer = $.setTimeout(() => {
                topicEdit.style.display = 'none';
                $.clearTimeout(timer);
            }, 300); // 0.3s 后执行

        }, false)
    };

    /**
     * @desc 删除菜单栏的高亮效果
     * @author _king
     */
    let removeActiveClass = () => {
        // 判断是否为主页
        if ($.location.pathname !== "/Home.aspx" && $.location.pathname !== '/') {
            const menu = document.getElementsByClassName('menu')[0];

            if (!menu) {
                return;
            }

            let active = menu.getElementsByClassName('active')[0];

            active.classList.remove('active');
        }
    };

    /**
     * @desc 显示回复发布区域
     * @author _king
     */
    let showPubReplyArea = () => {
        const cmnt = document.getElementsByClassName('comment')[0];

        if (!cmnt) {
            return;
        }

        let item = cmnt.getElementsByClassName('item');

        // TODO: 待优化
        for (let i = 0, len = item.length; i < len; i++) {
            let meta      = item[i].getElementsByClassName('meta');
            let hidden    = item[i].getElementsByClassName('hidden')[0];
            let cmntReply = item[i].getElementsByClassName('cmnt-reply')[0];
            
            if (!cmntReply) {
                return;
            }

            let aimsUser    = cmntReply.getElementsByClassName('aims-user');
            let aimsUserArr = [];

            for (let j = 0, leng = aimsUser.length; j < leng; j++) {
                if (aimsUser[j].innerText.length === 0) { // 找出无回复目标的用户链接
                    aimsUserArr.push(j);
                }
            }

            let _len   = aimsUser.length;
            let _count = 0;

            aimsUserArr.forEach(item => {

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
            for (let j = 0, leng = meta.length; j < leng; j++) {
                let reply = meta[j].getElementsByClassName('reply')[0];

                // 为评论回复的回复按钮添加点击事件
                //
                reply.addEventListener('click', () => {

                    let isLogin = isSignIn();

                    if (!isLogin) { 
                        rediret("/layout/SignIn.aspx"); // 未登录时，跳转到登录页
                        return;
                    }

                    hidden.classList.remove('hidden'); // 显现回复框

                    let name     = meta[j].parentElement.getElementsByClassName('name')[0]; // 获取评论对象的名字
                    let textarea = hidden.getElementsByTagName('textarea')[0];
                    let aimsId   = reply.getAttribute('data-aims-id');

                    textarea.value = ''; // 清空输入框

                    // 设置回复目标 ID
                    if (aimsId) {
                        let hdnAimsId   = hidden.getElementsByTagName('input')[0];
                        hdnAimsId.value = aimsId;
                    }

                    // 为回复框设置 placeholder
                    // e.g. `@test`
                    let placeHolderStr = name ? `@${name.innerText}` : '写下你的回复（140 字以内）';

                    textarea.setAttribute('placeholder', placeHolderStr);

                    textarea.focus(); // 聚焦

                    // 计时器 0s 后回调设置模糊度为 1
                    let timer = setTimeout(() => {
                        hidden.style.opacity = '1';
                        clearTimeout(timer);
                    }, 0);

                    let cancel = hidden.getElementsByClassName('cancel')[0]; // 取消按钮
                    let pubBtn = hidden.getElementsByClassName('reply-btn')[0].getElementsByTagName('input')[0]; // 回复按钮

                    // console.log(pubBtn);

                    // 为取消按钮添加点击事件
                    cancel.addEventListener('click', () => {
                        hidden.style.opacity = '0';

                        let timer = setTimeout(() => {
                            hidden.classList.add('hidden');
                            clearTimeout(timer);
                        }, 300); // 0.3s 后设置 hidden 的 display 为 none
                    }, false);

                    // 点击回复按钮时，隐藏回复区域
                    pubBtn.addEventListener('click', () => {
                        hidden.classList.add('hidden');
                    }, false);

                }, false);
            }
        }
    };

    /**
     * @desc 跳转页面
     * @param {string} url 跳转页的地址
     * @author _king
     */
    let rediret = url => {
        $.location.href = url;
    };

    /**
     * @desc 动画 - 粒子动画, 应用于登录注册页
     * @author Hnsn Wu
     */
    let showCanvasAnimation = () => {

        // 圆形
        class Circle {

            constructor(x, y) {
                this.x = x;
                this.y = y;
                this.r = Math.random() * 14 + 1;
                this._mx = Math.random() * 2 - 1;
                this._my = Math.random() * 2 - 1;
            }

            drawCircle(ctx) {
                ctx.beginPath();
                ctx.arc(this.x, this.y, this.r, 0, 360);
                ctx.closePath();
                ctx.fillStyle = '#fdebeb';
                ctx.fill();
            }

            drawLine(ctx, _circle) {
                let dx = this.x - _circle.x;
                let dy = this.y - _circle.y;
                let d = Math.sqrt(dx * dx + dy * dy);
                if (d < 150) {
                    ctx.beginPath();
                    ctx.moveTo(this.x, this.y);//起始点  
                    ctx.lineTo(_circle.x, _circle.y);//终点  
                    ctx.closePath();
                    ctx.strokeStyle = '#fdebeb';
                    ctx.stroke();
                }
            }

            move(w, h) {
                this._mx = (this.x < w && this.x > 0) ? this._mx : (-this._mx);
                this._my = (this.y < h && this.y > 0) ? this._my : (-this._my);
                this.x += this._mx / 2;
                this.y += this._my / 2;
            }
        }

        class currentCircle extends Circle {
            constructor(x, y) {
                super(x, y);
            }
        }

        // This `$` is `window` object!
        //

        $.requestAnimationFrame = $.requestAnimationFrame ||
            $.mozRequestAnimationFrame ||
            $.webkitRequestAnimationFrame ||
            $.msRequestAnimationFrame;

        let canvas = document.querySelector("#canvas");

        if (!canvas) {
            return;
        }

        let ctx            = canvas.getContext("2d");
        let w              = canvas.width  = canvas.offsetWidth;
        let h              = canvas.height = canvas.offsetHeight;
        let circles        = [];
        let current_circle = new currentCircle(0, 0);

        let draw = () => {
            ctx.clearRect(0, 0, w, h);
            for (let i = 0; i < circles.length; i++) {
                circles[i].move(w, h);
                circles[i].drawCircle(ctx);

                for (let j = i + 1; j < circles.length; j++) {
                    circles[i].drawLine(ctx, circles[j])
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

        let init = num => {
            for (var i = 0; i < num; i++) {
                circles.push(new Circle(Math.random() * w, Math.random() * h));
            }
            draw();
        };

        $.addEventListener('load', init(80));

        $.onmousemove = (e) => {
            e = e || window.event;
            current_circle.x = e.clientX;
            current_circle.y = e.clientY;
        }, $.onmouseout = () => {
            current_circle.x = null;
            current_circle.y = null;
        };
    };

    /**
     * @desc 放大图片 - 应用于启示详情页
     * @author Hnsn Wu
     */
    let zoomGoodsImg = () => {
        const zoomContainer = document.getElementById('zoom-container');

        if (!zoomContainer) {
            return;
        }

        const moimg    = zoomContainer.getElementsByClassName('zoom-img')[0];
        const goodsImg = zoomContainer.parentElement.getElementsByClassName('goods-img')[0];
        const caption  = zoomContainer.getElementsByClassName('caption')[0];
        const close    = zoomContainer.getElementsByClassName("close")[0];

        // 物品图片添加点击事件
        goodsImg.addEventListener('click', () => {
            zoomContainer.style.display = 'block';
            moimg.src                   = goodsImg.src;
            caption.innerHTML           = goodsImg.alt;
        }, false);

        // 点击关闭放大图片
        close.addEventListener('click', () => {
            zoomContainer.style.display = 'none';
        }, false);
    };

    /**
     * @desc 重设图片大小 - 应用于首页
     * @author _king
     */
    let resetImgSize = () => {
        // TODO:
    };

    /**
     * @desc 在非首页显示登录链接
     * @author _king
     */
    let showSignInLink = () => {
        let linkSignIn = document.getElementsByClassName('link-signin')[0];

        if (!linkSignIn) {
            return;
        }

        // 通过 cookie 判断用户是否登录
        // let isSignIn = getCookie('IsSignIn');  // TODO: 此处代完善

        let isLogin = isSignIn();

        if ($.location.pathname !== '/Home.aspx' && $.location.pathname !== '/' && isLogin !== true) {
            linkSignIn.style.display = 'block';
        }
    };

    /**
     * @desc 通过判断 UserProfile 元素是否存在来判断用户是否登录
     * @author _king
     * @returns {Bool}
     */
    let isSignIn = () => {
        let userProfile = document.getElementById('UserProfile');

        return !userProfile ? false : true;
    };

    /**
     * @desc 根据 name 读取 cookie
     * @param  {String} name 
     * @return {String} cookie 值
     * @author _king
     */
    let getCookie = name => {
        let arr = document.cookie.replace(/\s/g, '').split(';');

        for (let i = 0, len = arr.length; i < len; i++) {
            let tempArr = arr[i].split('=');

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
    let showUnderlineForTablist = () => {
        const tablist = document.getElementsByClassName('tablist');
        
        if (!tablist || tablist.length == 0) {
            return;
        }

        let tablistArr = Array.prototype.slice.call(tablist, 0); // 将 DOM 元素转化成数组

        tablistArr.forEach(item => {
            item.addEventListener('click', event => {
                let target    = event.target || event.srcElement;
                let tagName   = target.tagName.toLowerCase();
                let active    = item.querySelector('.active');
                let activeBtn = item.querySelector('.active-btn');

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
    let attr = (dom, json) => {

        if(typeof dom != 'object' || typeof json !== 'object') {
            return;
        }

        for (let key in json) {
            if (json.hasOwnProperty(key)) {
                const value = json[key];
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
    let $get = idClassTagStr => {

        if (idClassTagStr.startsWith('.')) {
            return document.getElementsByClassName(idClassTagStr.substr(1)); // class
        } else if (idClassTagStr.startsWith('#')) {
            return document.getElementById(idClassTagStr.substr(1));         // id
        } else {
            return document.getElementsByTagName(idClassTagStr);             // tag name
        }
    };

    /**
     * @desc 将 DOM 元素转换成 数组
     * @param {object} dom DOM 元素
     * @returns {object} DOM 元素数组
     * @author _king
     */
    let domToArray = dom => {
        return typeof dom === 'object' ? Array.prototype.slice.call(dom) : null;
    };

    /*
     * @desc 创建一个 DOM 元素
     * @param {string} tag 标签名
     * @returns {object} DOM 元素
     * @author _king
     */
    let $newtag = tag => {
        return document.createElement(tag);
    };

    /**
     * @desc 显示搜索话题的 Div - 应用与动态发布页，点击发表按钮时触发
     * @author _king
     */
    let showSearchTopicDiv = () => {

        const pubCurrentBtn = $get('#pub-current-btn');

        if (!pubCurrentBtn) {
            return;
        }

        const selectTopic = $get('.select-topic')[0];
        const cancelBtn = $get('.cancel-btn')[0];  // 取消按钮

        pubCurrentBtn.addEventListener('click', () => {
            selectTopic.style.opacity = '1';
            pubCurrentBtn.classList.add('clicked');
        }, false);

        cancelBtn.addEventListener('click', () => {
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
    let searchTopicItem = () => {
        let searchItems = $get('.search-items')[0];

        if (!searchItems) {
            return;
        }

        let selector = $get('#LbTopic');
        let selectorFrag = document.createDocumentFragment();
        let selectorDiv  = $newtag('div');
        let optionUl     = $newtag('ul');

        // 属性的设置

        attr(selectorDiv, {
            'class': 'multiple-search-selector'
        });

        attr(optionUl, {
            'class': 'options'
        });

        selectorDiv.appendChild(optionUl); // ul -> div

        // 移植搜索项

        let selectorArr = domToArray(selector); // DOM 转数组

        selectorArr.forEach(option => {

            if (!option.disabled) {
                let li = $newtag('li');

                attr(li, {
                    'class': 'item',
                    'data-index': option.index,
                    'data-value': option.value,
                    'selected'  : false
                }).textContent = option.textContent;

                optionUl.appendChild(li); // li -> ul
            }
        });

        let selectedItems     = $get('.selected-items')[0];
        let selectedItemsFrag = document.createDocumentFragment(); // 保存选中项

        // 添加点击事件
        optionUl.addEventListener('click', event => {
            let target = event.target || event.srcElement;

            if (selectedItems.childNodes.length == 3) {
                return;
            }

            // 选中项
            if (target.classList.contains('item')) {
                let index = target.getAttribute('data-index'); // 获取选中项的索引

                selector.options[index].selected = true; // 为真实的下拉框设置选中项
                attr(target, {'selected': true});        // 已选项下次匹配不显示

                if (target.classList.contains('active')) {
                    target.classList.remove('active');
                }

                // 添加选中项
                let selectedItemSpan = $newtag('span');
                let iconDelete       = $newtag('i');

                attr(selectedItemSpan, {
                    'class'              : 'item',
                    'data-selected-index': index
                }).textContent = target.textContent;

                attr(iconDelete, {
                    'class': 'icon-delete'
                }).addEventListener('click', () => {

                    selector.options[index].selected = false;
                    attr(target, { 'selected': false });

                    selectedItemSpan.parentElement.removeChild(selectedItemSpan);

                }, false);

                selectedItemSpan.appendChild(iconDelete); // i -> span

                selectedItemsFrag.appendChild(selectedItemSpan); // span -> frag
                selectedItems.appendChild(selectedItemsFrag); // frag -> selected items div
            }
        }, false);

        selectorFrag.appendChild(selectorDiv); // div -> frag
        selector.parentElement.appendChild(selectorFrag); // frag -> select parent

        // 开始搜索 - 简易的搜索

        let searchTopicInput = $get('#SearchTopic'); // 搜索框

        searchTopicInput.addEventListener('keyup', () => {
            let value = searchTopicInput.value;
            let items = optionUl.getElementsByClassName('item');

            for (let i = 0, length = items.length; i < length; i++) {

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
    showCardSlide          ();
    showDropMenu           ();
    showPromptInfo         ();
    showValitorInfo        ();
    uploadImgPreview       ();
    showTopicEdit          ();
    removeActiveClass      ();
    showPubReplyArea       ();
    showCanvasAnimation    ();
    zoomGoodsImg           ();
    showSignInLink         ();
    showUnderlineForTablist();
    searchTopicItem        ();
    showSearchTopicDiv     ();

}(window);