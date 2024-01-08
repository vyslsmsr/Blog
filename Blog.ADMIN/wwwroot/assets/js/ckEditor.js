var editor = CKEDITOR.replace('ckeditor', {
	extraPlugins: 'dialog,colordialog,colorbutton,colordialog'
});
editor.on('instanceReady', function (evt) {
	evt.editor.addCommand('h2', new CKEDITOR.styleCommand(new CKEDITOR.style({ element: 'h2' })));
	evt.editor.setKeystroke(CKEDITOR.CTRL + 50 /*U*/, 'h2');
});