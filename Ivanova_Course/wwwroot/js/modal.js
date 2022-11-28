'use strict';

// модальное окно показать / скрыть
$(function () {
    // проверка на IE
    function isInternetExplorer() {
        return window.navigator.userAgent.indexOf('MSIE ') > -1 || window.navigator.userAgent.indexOf('Trident/') > -1;
    }

    // "класс" для объектов модального окна
    function ModalWindow(modalElem) {
        this._$modalWindow = null;
        this._$closeBtn = null;
        this._$overlay = $('.overlay'),
            this._$pageBody = $("body");
        this._originZ = null;


        if (modalElem) {
            this._$modalWindow = modalElem instanceof jQuery ? modalElem : $(modalElem);
            this._$closeBtn = this._$modalWindow.find(".modal-close");
        }


        this.close = function () {
            this._$modalWindow.removeClass('active').removeClass('last-active');

            if (!this._originZ) {
                this._$overlay.removeClass('active');
            } else {
                this._$overlay.css({ 'z-index': this._originZ - 1 });
            }

            this._$pageBody.css({ 'overflow': 'auto' });

            this._$modalWindow.trigger("ModalWindow.close");
        }


        this.open = function () {
            if ($(".modal.active").length) {
                this._originZ = parseInt($(".modal.active").css('z-index'));
            } else {
                this._$overlay.addClass('active');
                this._$pageBody.css({ 'overflow': 'hidden' });
            }

            this._$modalWindow.addClass('active');

            if (this._originZ) {
                this._$modalWindow.css({ 'z-index': this._originZ + 3 }).addClass('last-active');
                this._$overlay.css({ 'z-index': this._originZ + 2 });
            }

            this._$modalWindow.trigger("ModalWindow.open");
        }

        // если ie то выключаем margin для позиционирования по центру экрана
        if (isInternetExplorer() === false) {
            return false;
        } else {
            $('.modal-content').css({ 'margin': 0 });
        }
    }

    // Этот модуль сам вызывается при загрузке на страницу. После этого, на DOM-элементах появляется data-атрибут ModalWndow,
    // в котором лежит объект класcа ModalWindow - у него можно вызывать методы.
    // На самом DOM-элементе можно слушать события 'ModalWindow.open'/'ModalWindow.close'
    // Пример вызова:
    /*
     * $('#HomeModal').data('ModalWndow').open()
     * $('#HomeModal').data('ModalWndow').close()
     * 
     * также работают старые вызовы через клик на '.modal-open'
     * 
     * $('#HomeModal').on('ModalWindow.open', function() {});
     * $('#HomeModal').on('ModalWindow.close', function() {});
     * */
    window["ModalWidget"] = (function () {

        var ESC_KEYCODE = 27;


        function initGlobal() {
            var $declaredModals = $("section.modal");

            $declaredModals.each(function (idx) {
                $(this).data('ModalWindow', new ModalWindow($(this)));
            });

            if ($declaredModals.length) {
                $(document).on('click', '.modal-open', onOpenBtnClick);
                $(document).on('click', '.modal-close', onCloseBtnClick);
                $(document).on('keydown', onKeyPress);
            }
        }


        function onOpenBtnClick(evt) {
            var modalId = $(this).data('modal');
            var $targetModal = $('.modal[data-modal="' + modalId + '"]');

            var targetModalWindowObj = $targetModal.data('ModalWindow');

            targetModalWindowObj.open();
        }


        function onCloseBtnClick(evt) {
            var $targetModal = $(this).closest('.modal');

            var targetModalWindowObj = $targetModal.data('ModalWindow');
            targetModalWindowObj.close();
        }


        function onKeyPress(evt) {
            var $targetModal;

            if (evt.keyCode === ESC_KEYCODE) {
                $targetModal = $(".modal.active").length > 1 ? $(".modal.active.last-active") : $(".modal.active");

                if ($targetModal.length) {
                    $targetModal.data('ModalWindow').close();
                }
            }
        }

        initGlobal();
    })();
});