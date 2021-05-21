
export const QuillConfigurationTextRitch = {
  
  ckeConfigar: {
    allowedContent: false,
    forcePasteAsPlainText: false,
    // contentsLangDirection: "ltr",
    extraPlugins: 'divarea',
    font_names: 'Arial;Times New Roman;Verdana',
    language: 'ar',
    autoParagraph :false,
    toolbarGroups: [
      // { name: 'document', groups: ['mode', 'document', 'doctools'] },
      // { name: 'clipboard', groups: ['clipboard', 'undo'] },
      // { name: 'editing', groups: ['find', 'selection', 'spellchecker', 'editing'] },
      // { name: 'forms', groups: ['forms'] },
      '/',
      { name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
      { name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi', 'paragraph'] },
      { name: 'links', groups: ['links'] },
      { name: 'insert', groups: ['insert'] },
      '/',
      { name: 'styles', groups: ['styles'] },
      { name: 'colors', groups: ['colors'] },
      { name: 'tools', groups: ['tools'] },
      { name: 'others', groups: ['others'] },
   { name: 'Source' },

      { name: 'about', groups: ['about'] }
      
    ],
    removeButtons: 'document,doctools,mode,Save,NewPage,Preview,Print,Image,Templates,PasteText,PasteFromWord,Undo,Redo,Find,Replace,SelectAll,Scayt,Form,Checkbox,Radio,TextField,Textarea,Select,Button,ImageButton,HiddenField,Strike,Subscript,Superscript,CopyFormatting,RemoveFormat,Outdent,Indent,CreateDiv,Blockquote,BidiLtr,BidiRtl,Unlink,Anchor,Flash,HorizontalRule,SpecialChar,PageBreak,Iframe,Maximize,ShowBlocks,About'
  },

  ckeConfigen: {
    allowedContent: false,
    forcePasteAsPlainText: false,
    extraPlugins: 'divarea',
    font_names: 'Arial;Times New Roman;Verdana',
    contentsLangDirection: "rtl",
    language: 'en',
    autoParagraph :false,
    toolbarGroups: [
      // { name: 'document', groups: ['mode', 'document', 'doctools'] },
      // { name: 'clipboard', groups: ['clipboard', 'undo'] },
      // { name: 'editing', groups: ['find', 'selection', 'spellchecker', 'editing'] },
      // { name: 'forms', groups: ['forms'] },
      '/',
      { name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
      { name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi', 'paragraph'] },
      { name: 'links', groups: ['links'] },
      { name: 'insert', groups: ['insert'] },
      '/',
      { name: 'styles', groups: ['styles'] },
      { name: 'colors', groups: ['colors'] },
      { name: 'tools', groups: ['tools'] },
      { name: 'others', groups: ['others'] },
      { name: 'about', groups: ['about'] }
    ],
    removeButtons: 'Source,Save,NewPage,Preview,Print,Image,Templates,PasteText,PasteFromWord,Undo,Redo,Find,Replace,SelectAll,Scayt,Form,Checkbox,Radio,TextField,Textarea,Select,Button,ImageButton,HiddenField,Strike,Subscript,Superscript,CopyFormatting,RemoveFormat,Outdent,Indent,CreateDiv,Blockquote,BidiLtr,BidiRtl,Unlink,Anchor,Flash,HorizontalRule,SpecialChar,PageBreak,Iframe,Maximize,ShowBlocks,About'
  }
}

