﻿#pragma checksum "..\..\..\revisionExamen.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6C3345CD28AE8E24623507967CEB3742BF83E327"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Clinica_medica_polanco;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Clinica_medica_polanco {
    
    
    /// <summary>
    /// revisionExamen
    /// </summary>
    public partial class revisionExamen : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 177 "..\..\..\revisionExamen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Revision_Examen_Buscar;
        
        #line default
        #line hidden
        
        
        #line 178 "..\..\..\revisionExamen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Revision_Examen_Buscar;
        
        #line default
        #line hidden
        
        
        #line 179 "..\..\..\revisionExamen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtg_Revision_Examen_Examenes;
        
        #line default
        #line hidden
        
        
        #line 180 "..\..\..\revisionExamen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Revision_Examen_Salir;
        
        #line default
        #line hidden
        
        
        #line 185 "..\..\..\revisionExamen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Revision_Examen_Ir;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Clinica medica polanco;component/revisionexamen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\revisionExamen.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txt_Revision_Examen_Buscar = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.btn_Revision_Examen_Buscar = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.dtg_Revision_Examen_Examenes = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.btn_Revision_Examen_Salir = ((System.Windows.Controls.Button)(target));
            
            #line 180 "..\..\..\revisionExamen.xaml"
            this.btn_Revision_Examen_Salir.Click += new System.Windows.RoutedEventHandler(this.btn_Revision_Examen_Salir_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_Revision_Examen_Ir = ((System.Windows.Controls.Button)(target));
            
            #line 185 "..\..\..\revisionExamen.xaml"
            this.btn_Revision_Examen_Ir.Click += new System.Windows.RoutedEventHandler(this.btn_Revision_Examen_Ir_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

