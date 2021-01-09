'use strict';
console.log('this is trung.js');
export const trungGetClass = (classname, prefix = '') => {
    prefix = prefix.trim();
    classname = classname.trim();
    prefix = prefix.split('.')[0] ? prefix.split('.')[0] : prefix.split('.')[1];
    classname = classname.split('.')[0] ? classname.split('.')[0] : classname.split('.')[1];
    return `.${prefix}${classname}`;
}
export const trungGetClassName = (classname, prefix = '') => {
    prefix = prefix.trim();
    classname = classname.trim();
    prefix = prefix.split('.')[0] ? prefix.split('.')[0] : prefix.split('.')[1];
    classname = classname.split('.')[0] ? classname.split('.')[0] : classname.split('.')[1];
    return `${prefix}${classname}`;
}
export function isElement(obj) {
    try {
        //Using W3 DOM2 (works for FF, Opera and Chrome)
        return obj instanceof HTMLElement;
    }
    catch (e) {
        //Browsers not supporting W3 DOM2 don't have HTMLElement and
        //an exception is thrown and we end up here. Testing some
        //properties that all elements have (works on IE7)
        return (typeof obj === "object") &&
            (obj.nodeType === 1) && (typeof obj.style === "object") &&
            (typeof obj.ownerDocument === "object");
    }
}
export function revisedRandId() {
    return Math.random().toString(36).replace(/[^a-z]+/g, '').substr(2, 10);
}
export function trungReplacehtml(template, data) {
    const pattern = /\{(.*?)\}/g; // {property}
    return template.replace(pattern, (match, token) => data[token]);
}
export function setPosition(el, x, y) {
    x = !x ? 0 : x;
    y = !y ? 0 : y;

    //el[posKey] = [x, y];

    el.style.left = !isNaN(x) ? (x + 'px') : x;
    el.style.top = !isNaN(y) ? (y + 'px') : y;
}
//-----------------------------------------------------------------------
export class trungTemplate {
    constructor(name,value) {
        this.name = name;
        this.value = value;
        this.container = document.createElement('div');
        this.container.classList.add(trungGetClassName('popup-section-item', 'tui-full-calendar-'));
    }
    renderHTML(value) {
        this.input= document.createElement('input');
        this.input.classList.add(trungGetClassName('content', 'tui-full-calendar-'));
        this.input.value = value;
        this.input.addEventListener("change", this.onChange.bind(this));
        $(this.container).html(this.input);
        return this.container;
    }
    render(selector) {
        const layout = isElement(selector) ? selector : document.querySelector(selector);
        $(layout).html(this.renderHTML(this.value));
    }
    getValue() {
        return this.value = this.input ? this.input.value:this.value;
    }
    setValue(value) {
        this.value = value;
        if (this.input)
            this.input.value = value;
        return true;
    }
    onChange(e) {
        const selectedItem = e.currentTarget;
        if (!selectedItem || selectedItem.length == 0)
            return 0;
        this.setValue(selectedItem.value);
        if (this.onAfterChange)
            this.onAfterChange(e);
        return 1;
    }
    onAfterChange(e) {
        
    }
    show() {
        this.container.style.display = 'block';
    }
    hide() {
        this.container.style.display = 'none';
    }
    disable() {
        if(this.input)
            this.input.disabled = true;
    }
    enable() {
        if (this.input)
            this.input.disabled = false;
    }
}
export class trungInput extends trungTemplate {
    constructor(options = {}) {
        options.name = options.name || 'input_' + revisedRandId();
        options.value = options.value || '';
        super(options.name, options.value);
        this.setOptions(options);
    }
    setOptions(options) {
        this.placeholder = options.placeholder
            ? options.placeholder
            : (options.attrs && options.attrs.placeholder ? options.attrs.placeholder:'');
        this.icon = options.icon;
        this.width = options.width || null;
        this.height = options.height || null;
        this.type = options.type || 'text';
        this.attrs = options.attrs || null;
        this.label = options.label || null;
        this.id = options.id|| 'id_'+this.name + '_' + revisedRandId();
    }
    renderHTML(value) {
        if (this.type && this.type == 'textarea') {
            this.input = document.createElement('textarea');

        } else {
            this.input = document.createElement('input');
            this.input.type = this.type;
        }
        this.input.classList.add(trungGetClassName('content', 'tui-full-calendar-'));

        if (this.attrs) {
            for (let key in this.attrs) {
                this.input.setAttribute(key, this.attrs[key]);
            }
        }
        if (this.type == 'checkbox') {
            this.value = !!this.value;
            this.input.checked = this.value;
        } else
            this.input.value = value;
        this.input.name = this.name;
        this.input.id = this.id;
        this.input.placeholder = this.placeholder;
        this.input.addEventListener("change", this.onChange.bind(this));
        if (this.width)
            this.input.style.width = this.width;
        if (this.height)
            this.input.style.height = this.height;
        
        if (this.icon)
            $(this.container).html(this.icon);
        this.container.appendChild(this.input);
        if (this.label) {
            this.lb = document.createElement('label');
            this.lb.htmlFor = this.id;
            this.lb.innerHTML = this.label;
            this.lb.classList.add('form-check-label');
            this.container.appendChild(this.lb);
        }
        return this.container;
    }
    getValue() {
        if (this.type == 'checkbox') {
            return this.value = this.input ? this.input.checked : this.value;
        }
        return this.value = this.input ? this.input.value : this.value;
    }
    setValue(value) {
        this.value = !!value;
        if (this.type == 'checkbox') {
            if (this.input)
                return  this.input.checked = this.value;
        }
        if (this.input)
            return this.input.value = value;
    }
    onChange(e) {
        if (this.type == 'checkbox')
            return;
        const selectedItem = e.currentTarget;
        if (!selectedItem || selectedItem.length == 0)
            return 0;
        this.setValue(selectedItem.value);
        if (this.onAfterChange)
            this.onAfterChange(e);
        return 1;
    }
}
export class trungDropdown extends trungTemplate {
    constructor(options) {
        super();
        this.prefixClass = options.prefixClass || 'tui-full-calendar-';
        this.name = options.name || '_trungDropdown';
        this.value = options.value !== undefined
            ? options.value
            : (options.default !== undefined ? options.default : '');
        this.defaultBg = options.defaultBg || '';
        this.list = options.list || [];
        this.container = options.container ? document.querySelector(options.container) : document.createElement('div');
        this.container.classList.add(trungGetClassName('dropdown', this.prefixClass));
        this.container.classList.add(trungGetClassName('section-calendar', this.prefixClass));
    }
    renderHTML(value = {}) {
        const btn = this.btn = document.createElement('button');
        btn.classList.add(trungGetClassName('button', this.prefixClass));
        btn.classList.add(trungGetClassName('dropdown-button', this.prefixClass));
        btn.classList.add(trungGetClassName('popup-section-item', this.prefixClass));
        btn.classList.add('dropdown-toggle');
        btn.setAttribute('data-toggle', 'dropdown');

        const spanBg = this.spanBg = document.createElement('span');
        spanBg.classList.add(trungGetClassName('icon', this.prefixClass));
        spanBg.classList.add(trungGetClassName('calendar-dot', this.prefixClass));
        if (this.defaultBg) {
            spanBg.style.backgroundColor = this.defaultBg;
        } else {
            spanBg.style.display = 'none';
        }
        btn.appendChild(spanBg);
        const spanValue = document.createElement('span');
        spanValue.name = this.name;
        spanValue.classList.add(trungGetClassName('content', this.prefixClass));
        spanValue.innerHTML = 'Roomzxc';

        const spanArrow = document.createElement('span');
        spanArrow.classList.add(trungGetClassName('icon', this.prefixClass));
        spanArrow.classList.add(trungGetClassName('dropdown-arrow', this.prefixClass));

        
        btn.appendChild(spanValue);
        btn.appendChild(spanArrow);

        const ul = document.createElement('ul');
        ul.classList.add(trungGetClassName('dropdown-menu', this.prefixClass));
        ul.classList.add('dropdown-menu');
        let first_vl = null;
        this.list.forEach((element) => {
            const li = document.createElement('li');
            li.classList.add(trungGetClassName('popup-section-item', this.prefixClass));
            li.classList.add(trungGetClassName('dropdown-menu-item', this.prefixClass));
            if (element.value) {
                li.setAttribute('data-value', element.value);
            }
            if (this.value && this.value.value == element.value)
                first_vl = element;
            if (!first_vl)
                first_vl = element;

            if (element.bg) {
                const bg = spanBg.cloneNode(0);
                bg.style.backgroundColor = element.bg;
                bg.style.display = 'inline-block';
                li.appendChild(bg);
            }
            

            const content = spanValue.cloneNode(0);
            content.innerHTML = element.label;

            li.appendChild(content);
            li.addEventListener("click", this.onChange.bind(this));
            ul.appendChild(li);

        });

        this.container.appendChild(btn);
        this.container.appendChild(ul);
        this.setValue(first_vl);
        return this.container;
    }
    /*render(selector) {
        this.renderHTML();
        const layout = isElement(selector) ? selector: document.querySelector(selector);
        layout.appendChild(this.container);
    }*/
    show() {
        this.container.style.display = 'block';
    }
    hide() {
        this.container.style.display = 'none';
    }
    onChange(e) {
        const selectedItem = e.currentTarget;
        if (!selectedItem || selectedItem.length == 0)
            return 0;
        this.setValue(selectedItem);
        if (this.onAfterChange)
            this.onAfterChange(e);
        return 1;
    }
    /*getValue() {
        return this.value;
    }*/
    setValue(value) {
        if (isElement(value)) {
            const selectedItem = value;
            const vl = selectedItem.dataset.value;
            const bgColor =
                selectedItem.getElementsByClassName(trungGetClassName('icon', this.prefixClass))[0]
                    ? selectedItem.getElementsByClassName(trungGetClassName('icon', this.prefixClass))[0].style.backgroundColor
                    :null;
            const title = selectedItem.getElementsByClassName(trungGetClassName('content', this.prefixClass))[0]
                .innerHTML;
            const valueObj = { value: vl, label: title, bg: bgColor };
            this.setValue(valueObj);
        } else {
            if (value.label)
                this.btn.getElementsByClassName(trungGetClassName('content', this.prefixClass))[0].innerHTML = value.label;
            if (value.bg) {
                this.spanBg.style.backgroundColor = value.bg;
                this.spanBg.style.display = 'inline-block';
            } else {
                this.spanBg.style.display = 'none';
            }
                
            this.value = value;
        }
    }
}
export class trungSelect extends trungTemplate {
    constructor(options) {
        super(options.name);
        this.id = 'trungSelect_' + revisedRandId();
        this.input = document.createElement('select');
        //this.input.classList.add('form-control');
        this.input.id = this.id;
        this.options = {};
        this.ajaxOptions = null;
        this.setOptions(options);
    }
    setOptions(options) {
        if (options.ajax === false && this.ajaxOptions) {
            this.ajaxOptions = null;
        }
        if (options.ajax) {
            this.ajaxOptions = Object.assign({}, options.ajax);
            delete options.ajax;
            if (!this.ajaxOptions.success) {
                this.ajaxOptions.success = (res) => {
                    let data = this.ajaxOptions.processResults
                        ? this.ajaxOptions.processResults(res)
                        : (res.d ? res.d : res);
                    
                    this.options.options = data;
                    if (this.input.selectize) {
                        this.input.selectize.destroy();
                    }
                    $(this.input).selectize(this.options);
                    if (this.value)
                        this.setValue(this.value);
                    this.bindChange();
                };
            }
        }
        Object.assign(this.options, options);
    }
    reload(options=null) {
        if (this.input.selectize) {
            this.input.selectize.destroy();
        }
        if (options)
            this.setOptions(options);
        if (this.ajaxOptions) {
            $.ajax(this.ajaxOptions);
        } else {
            $(this.input).selectize(this.options);
            this.bindChange();
        }
        
    }
    bindChange() {
        if (!this.input.selectize)
            return false;
        if (this.options.onChange)
            this.onChange = this.options.onChange;
        if (this.onChange)
            this.input.selectize.on('change', this.onChange.bind(this));
    }
    renderHTML() {
        this.container.classList.remove('tui-full-calendar-popup-section-item');
        if (this.options.width)
            this.input.style.width = this.options.width;
        this.container.appendChild(this.input);
        return this.container;
    }
    render(selector) {
        const layout = isElement(selector) ? selector : document.querySelector(selector);
        $(layout).html(this.renderHTML(this.value));
        this.reload();
        /*if (this.ajaxOptions) {
            $.ajax(this.ajaxOptions);
        }*/
    }
    getValue() {
        return this.value = this.input.selectize ? this.input.selectize.getValue():null;
    }
    setValue(value, silent) {
        if (!this.input.selectize)
            return false;
        if ((this.options.create || this.options.createOnBlur)) {
            const valueField = this.options.valueField || 'id';
            const labelField = this.options.labelField || 'name';
            if (Array.isArray(value))
                for (let key in value) {
                    const text = value[key];
                    if (!this.input.selectize.options[text])
                        this.input.selectize.addOption({ [valueField]: text, [labelField]: text });
                }
            else if(!this.input.selectize.options[value])
                this.input.selectize.addOption({ [valueField]: value, [labelField]: value });
        }
        this.input.selectize.setValue(value, silent);
        return this.getValue();
    }
    onChange(value) {
        this.value = value;
        if (this.onAfterChange)
            this.onAfterChange(value);
    }
    onAfterChange(value) {

    }
    disable() {
        return this.input.selectize.disable();
    }
    enable() {
        return this.input.selectize.enable();
    }
}
export class trungFile extends trungTemplate {
    constructor(name, value=null) {
        super(name, value);
        this.container.classList.remove(trungGetClassName('popup-section-item', 'tui-full-calendar-'));
    }
    renderHTML(value) {
        let temp = `<div class="fileAttach" style="font-size: 13px;">
                         <div id="btnChosse">
                            <div class="qq-uploader">
                                <div class="qq-upload-drop-area" style="display: none;">
                                    <span>Kéo và thả vào để tải lên</span>
                                </div>
                                <div class="qq-upload-button" style="position: relative; overflow: hidden; direction: ltr;">
                                    <i class=" icon-paper-clip"></i> Chọn file đính kèm
                                    <input multiple="multiple" type="file" name="file" style="position: absolute; right: 0px; top: 0px; font-family: Arial; font-size: 118px; margin: 0px; padding: 0px; cursor: pointer; opacity: 0;">
                                </div>
                                <ul class="qq-upload-list"></ul>
                            </div>
                        </div>
                        <ul id="listFileAttach"></ul>
                        <ul id="listFileAttachRemove">`;
        if (value && value.length > 0) {
            for (let key in value) {
                let file = value[key];
                file.sortname = file.Ten.substring(0, 40);
                temp += trungReplacehtml(`
                    <li>
                        <span title="{Ten}" id="{ID}">
                            <a href="/Uploads/{Ten}">
                                {sortname}
                            </a>
                        </span>
                        <a href="javascript:DeleteFileUpdate('{ID}');">
                            <img border="0" title="Xóa file đính kèm" src="/Publishing_Resources/img/LastIcon/act_filedelete.png">
                        </a>                        
                    </li>


                `, file);
            }
        }
        temp += `</ul>
                      </div>`;
        this.container.innerHTML = temp;
        return this.container;
    }
    setValue(value) {
        this.value = value;
        $(this.container).html('');
        this.renderHTML(this.value);
        createUploader();

    }
    disable() {
        this.container.classList.add('disabled');
    }
    enable() {
        this.container.classList.remove('disabled');
    }
}
export class trungDatetime extends trungTemplate {
    renderHTML(value) {
        const input = this.input = document.createElement('input');
        input.classList.add(trungGetClassName('content', 'tui-full-calendar-'));
        input.value = value;
        input.id = this.name;
        input.placeholder = 'Start date';
        this.container.innerHTML = '<span class="tui-full-calendar-icon tui-full-calendar-ic-date"></span>';
        this.container.appendChild(input);
        const div = document.createElement('div');
        div.id = 'wrapper_'+this.name;
        div.style.marginLeft = '-1px';
        div.style.marginTop = '-1px';
        div.style.position = 'relative';
        this.container.appendChild(div);
        tui.DatePicker.localeTexts['tiengviet']={
            titles: {
                // days
                DD: ['Chủ nhật', 'Thứ hai', 'Thứ ba', 'Thứ tư', 'Thứ năm', 'Thứ 6', 'Thứ 7'],
                // daysShort
                D: ['CN', 'Thứ 2', 'Thứ 3', 'Thứ 4', 'Thứ 5', 'Thứ 6', 'Thứ 7'],
                // months
                MMMM: [
                    'Tháng 1', 'Tháng 2', 'Tháng 3', 'Tháng 4', 'Tháng 5', 'Tháng 6',
                    'Tháng 7', 'Tháng 8', 'Tháng 9', 'Tháng 10', 'Tháng 11', 'Tháng 12'
                ],
                // monthsShort
                MMM: [
                    'Tháng 1', 'Tháng 2', 'Tháng 3', 'Tháng 4', 'Tháng 5', 'Tháng 6',
                    'Tháng 7', 'Tháng 8', 'Tháng 9', 'Tháng 10', 'Tháng 11', 'Tháng 12'
                ]
            },
            titleFormat: 'MMMM - yyyy',
            todayFormat: 'D, Ngày dd - MMMM, yyyy'
        };
        this.datepicker = new tui.DatePicker(div, {
            date: value ? value : new Date(),
            input: {
                element: input,
                format: 'dd/MM/yyyy HH:mm'
            },
            timepicker: {// options: https://nhn.github.io/tui.time-picker/latest/tutorial-example02-using-meridiem
                layoutType: 'tab',
                inputType: 'selectbox',// 'spinbox' ,selectbox
                showMeridiem: false
            },
            language: 'tiengviet',
            showToday:false,
        });
        return this.container;
    }
    getValue() {
        return this.value = this.datepicker.getDate();
    }
    setValue(value) {
        this.value = value;
        this.datepicker.setDate(value);
    }
}
export class trungLayer {
    constructor(options = {}) {
        this.name = options.name || 'trungLayer_' + revisedRandId();
        this.prefixClass = options.prefixClass || 'tui-full-calendar-';
        this.isCreated = this.isCreated ? this.isCreated : false;
        this.sections = new Map();
        this.id = 0;
        this.state = '';// 'create' or 'update', hien chua xai. state dua theo this.id, create neu id=0

        this.container = options.container ? document.querySelector(options.container) : document.createElement('div');
        this.container.classList.add(trungGetClassName('floating-layer', this.prefixClass));
        this.container.style.display = 'none';
        this.container.style.position = 'absolute';

        this.popup = document.createElement('div');
        this.popup.classList.add(trungGetClassName('popup', this.prefixClass));

        this.popupContainer = document.createElement('div');
        this.popupContainer.classList.add(trungGetClassName('popup-container', this.prefixClass));
        this.btnClose = document.createElement('button');
        this.btnClose.classList.add(trungGetClassName('button', this.prefixClass));
        this.btnClose.classList.add(trungGetClassName('popup-close', this.prefixClass));
        this.btnClose.innerHTML = '<span class="tui-full-calendar-icon tui-full-calendar-ic-close"></span>';
        this.btnClose.setAttribute('type', 'button');
        this.btnClose.addEventListener("click", this.hide.bind(this));
        this.popupContainer.appendChild(this.btnClose);

        this.wrapperSave = document.createElement('div');
        this.wrapperSave.classList.add(trungGetClassName('section-button-save', this.prefixClass));
        this.btnSave = document.createElement('button');
        this.btnSave.classList.add(trungGetClassName('button', this.prefixClass));
        this.btnSave.classList.add(trungGetClassName('confirm', this.prefixClass));
        this.btnSave.classList.add(trungGetClassName('popup-save', this.prefixClass));
        this.btnSave.innerHTML = '<span>Lưu</span>';
        this.btnSave.setAttribute('type', 'button');
        this.wrapperSave.appendChild(this.btnSave);
        this.popupContainer.appendChild(this.wrapperSave);

        this.popupArrow = document.createElement('div');
        this.popupArrow.classList.add(trungGetClassName('popup-arrow', this.prefixClass));
        this.popupArrow.classList.add(trungGetClassName('arrow-bottom', this.prefixClass));
        this.arrow = document.createElement('div');
        this.arrow.classList.add(trungGetClassName('popup-arrow-border', this.prefixClass));
        this.arrow.innerHTML ='<div class="tui-full-calendar-popup-arrow-fill"></div>';
        this.popupArrow.appendChild(this.arrow);

        this.popup.appendChild(this.popupContainer);
        this.popup.appendChild(this.popupArrow);
        this.container.appendChild(this.popup);
        trungLayer.instances.push(this);
        this.setOptions(options);
    }
    setOptions(options) {
        for (let property in options) {
            if (['name','container'].includes(property)) {
                continue;
            }
            if (property == 'sections' && options.sections) {
                for (let name in options.sections) {
                    this.createSection(name, options.sections[name]);
                }
            } else {
                this[property] = options[property];
            }
        }
        this.id = options.id || 0;
    }
    createSection(name='',template) {
        name = name ? `section_${name}` : 'section_' + revisedRandId();
        const section = this[name] ? this[name]: document.createElement('div');
        section.classList.add(trungGetClassName('popup-section', this.prefixClass));
        section.classList.add(name);
        let _template;
        if (typeof template === 'string' || template instanceof String)
            _template = new trungTemplate(name, template);
        else if (!(template instanceof trungTemplate) && !(template instanceof trungDropdown)) {
            template.name = name;
            _template = new trungTemplate(name, template.value);
            if (template.renderHTML)
                _template.renderHTML = template.renderHTML;
        } else
            _template = template;

        _template.render(section);
        if (!this[name])
            this.popupContainer.insertBefore(section,this.wrapperSave);
        this.sections.set(name, _template);
        return this[name]= section;
    }
    getSection(name) {
        name = `section_${name}`;
        if (this.sections.has(name))
            return this.sections.get(name);
        return null;
    }
    getSectionDom(name) {
        name = `section_${name}`;
        return this[name];
    }
    getSectionValue(name) {
        name = `section_${name}`;
        if (this.sections.has(name) && this.sections.get(name).getValue)
            return this.sections.get(name).getValue();
        return null;
    }
    setSectionValue(name,value) {
        name = `section_${name}`;
        if (this.sections.has(name) && this.sections.get(name).setValue)
            return this.sections.get(name).setValue(value);
        return null;
    }
    show() {
        this.container.style.display = 'block';
    }
    hide() {
        this.container.style.display = 'none';
    }
    isHidden() {
        return this.container.style.display == 'none';
    }
    render(selector) {
        const layout = isElement(selector) ? selector : document.querySelector(selector);
        if (!this.isCreated) {
            layout.appendChild(this.container);
            if (this.onAfterRender)
                this.onAfterRender(selector);
            this.isCreated = true;
        }
        this.show();
    }
    onAfterRender(selector) {
        return true;
    }
    calcRenderingData(guideBound) {
        var layerSize = {
            width: this.popup.offsetWidth,
            height: this.popup.offsetHeight
        };
        var parentSize = {
            right: window.innerWidth,
            bottom: window.innerHeight
        };
        var guideHorizontalCenter = (guideBound.left + guideBound.right) / 2;
        var x = guideHorizontalCenter - (layerSize.width / 2);
        var y = guideBound.top - layerSize.height + 3;
        var arrowDirection = 'arrow-bottom';
        //var arrowLeft = '-7px';
        var arrowLeft;

        if (y < 0) {
            y = guideBound.bottom + 9;
            arrowDirection = 'arrow-top';
        }

        if (x > 0 && (x + layerSize.width > parentSize.right)) {
            x = parentSize.right - layerSize.width;
        }

        if (x < 0) {
            x = 0;
        }

        if (guideHorizontalCenter - x !== layerSize.width / 2) {
            arrowLeft = guideHorizontalCenter - x - 8;
        }

        /**
         * @typedef {Object} PopupRenderingData
         * @property {number} x - left position
         * @property {number} y - top position
         * @property {string} arrow.direction - direction of popup arrow
         * @property {number} [arrow.position] - relative position of popup arrow, if it is not set, arrow appears on the middle of popup
         */
        return {
            x: x,
            y: y,
            arrow: {
                direction: arrowDirection,
                position: arrowLeft
            }
        };
    }
    setArrowDirection(arrow) {
        var direction = arrow.direction || 'arrow-bottom';
        var arrowEl = this.popupArrow;
        var borderElement = this.arrow;

        if (direction !== 'arrow-bottom') {
            $(arrowEl).removeClass('tui-full-calendar-arrow-bottom');
            $(arrowEl).addClass('tui-full-calendar-' + direction);
        } else {
            $(arrowEl).removeClass('tui-full-calendar-arrow-top');
            $(arrowEl).addClass('tui-full-calendar-' + direction);
        }

        if (arrow.position) {
            borderElement.style.left = arrow.position + 'px';
        } else
            borderElement.removeAttribute("style");
    }
    display(selector, guideBound, parentBounds = null) {
        this.render(selector);
        if (!parentBounds) {
            const parentRect = $('.tui-full-calendar-layout')[0].getBoundingClientRect();
            parentBounds = {
                left: parentRect.left,
                top: parentRect.top
            };
        }
        var pos = this.calcRenderingData(guideBound);
        pos.x -= parentBounds.left;
        pos.y -= (parentBounds.top + 6);
        setPosition(this.container, pos.x, pos.y);
        this.setArrowDirection(pos.arrow);
    }
    onSave(call) {
        this.btnSave.addEventListener("click", call.bind(this));
    }
    getAllValue() {
        let out = {};
        if (this.sections.size === 0)
            return out;
        for (let [name, template] of this.sections) {
            const n = name.split('_').slice(1).join('_');
            out[n] = this.getSectionValue(n);
        }
        return out;
    }
    setValues(data = {}) {
        for (const sessionname in data) {
            // ko break;
            switch (sessionname) {
                case 'start':
                    this.setSectionValue('startdate', data[sessionname]);
                case 'end':
                    this.setSectionValue('enddate', data[sessionname]);
                
                default:
                    this.setSectionValue(sessionname, data[sessionname]);
            }
       
        }
    }
    clearSectionsData(except = []) {
        if (this.sections.size > 0) {
            for (let [name, template] of this.sections) {
                const n = name.split('_').slice(1).join('_');
                if (except.includes(n))
                    continue;
                this.setSectionValue(n,null);
            }
        }
        if (this.onAfterClearSectionsData)
            this.onAfterClearSectionsData();
    }
    onAfterClearSectionsData() {

    }
    disableSections(except=[]) {
        if (this.sections.size > 0) {
            for (let [name, template] of this.sections) {
                const n = name.split('_').slice(1).join('_');
                if (except.includes(n))
                    continue;
                if (template.disable)
                    template.disable()
            }
        }
	    this.wrapperSave.style.display = 'none';
    }
    enableSections(except = []) {
        if (this.sections.size > 0) {
            for (let [name, template] of this.sections) {
                const n = name.split('_').slice(1).join('_');
                if (except.includes(n))
                    continue;
                if (template.enable)
                    template.enable()
            }
        }
	    this.wrapperSave.style.display = 'block';
    }
}

trungLayer.instances = [];
trungLayer.getInstance = (name) => {
    if (trungLayer.instances.length == 0)
        return null;
    for (let i = 0; i < trungLayer.instances.length; i++) {
        if (trungLayer.instances[i].name == name)
            return trungLayer.instances[i];
    }
    return null;
};
trungLayer.instance = (name='',options = {}) => {
    if (name && !!trungLayer.getInstance(name)) {
        const l = trungLayer.getInstance(name);
        l.setOptions(options);
        return l;
    }
    if (name)
        options.name = name;
    return new trungLayer(options);
}