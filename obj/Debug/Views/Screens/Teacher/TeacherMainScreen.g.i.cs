﻿#pragma checksum "..\..\..\..\..\Views\Screens\Teacher\TeacherMainScreen.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "84442F1BC80AD3DA097675E642820FEC4DFE74021D416014D88B3978787BBEBA"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using DocumentArchive.Views.Screens.Teacher;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace DocumentArchive.Views.Screens.Teacher {
    
    
    /// <summary>
    /// TeacherMainScreen
    /// </summary>
    public partial class TeacherMainScreen : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 33 "..\..\..\..\..\Views\Screens\Teacher\TeacherMainScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnUploadFile;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\..\Views\Screens\Teacher\TeacherMainScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbSearchQuery;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\..\Views\Screens\Teacher\TeacherMainScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnNextStrings;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\..\Views\Screens\Teacher\TeacherMainScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox LbPinnedFiles;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\..\Views\Screens\Teacher\TeacherMainScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnPreviousStrings;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\..\Views\Screens\Teacher\TeacherMainScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DgPublicFiles;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\..\..\..\Views\Screens\Teacher\TeacherMainScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Run RnCountFiles;
        
        #line default
        #line hidden
        
        
        #line 155 "..\..\..\..\..\Views\Screens\Teacher\TeacherMainScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Run RnLastUpdate;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DocumentArchive;component/views/screens/teacher/teachermainscreen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Screens\Teacher\TeacherMainScreen.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.BtnUploadFile = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\..\..\Views\Screens\Teacher\TeacherMainScreen.xaml"
            this.BtnUploadFile.Click += new System.Windows.RoutedEventHandler(this.BtnUploadFile_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TbSearchQuery = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.BtnNextStrings = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\..\..\Views\Screens\Teacher\TeacherMainScreen.xaml"
            this.BtnNextStrings.Click += new System.Windows.RoutedEventHandler(this.BtnNextStrings_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LbPinnedFiles = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.BtnPreviousStrings = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\..\..\..\Views\Screens\Teacher\TeacherMainScreen.xaml"
            this.BtnPreviousStrings.Click += new System.Windows.RoutedEventHandler(this.BtnPreviousStrings_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DgPublicFiles = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.RnCountFiles = ((System.Windows.Documents.Run)(target));
            return;
            case 9:
            this.RnLastUpdate = ((System.Windows.Documents.Run)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 7:
            
            #line 131 "..\..\..\..\..\Views\Screens\Teacher\TeacherMainScreen.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnOpenReader_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
