﻿#pragma checksum "..\..\..\entregarExamen.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8B899B21828E484AD1B4E16F525DDD4DB204307B"
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
    /// entregarExamen
    /// </summary>
    public partial class entregarExamen : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 177 "..\..\..\entregarExamen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Entrega_Examen_Buscar;
        
        #line default
        #line hidden
        
        
        #line 178 "..\..\..\entregarExamen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Entrega_Examen_Buscar;
        
        #line default
        #line hidden
        
        
        #line 179 "..\..\..\entregarExamen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtg_Entrega_Examen_Examenes;
        
        #line default
        #line hidden
        
        
        #line 180 "..\..\..\entregarExamen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Entrega_Examen_Salir;
        
        #line default
        #line hidden
        
        
        #line 185 "..\..\..\entregarExamen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Entrega_Examen_Correo;
        
        #line default
        #line hidden
        
        
        #line 186 "..\..\..\entregarExamen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Entrega_Examen_Fisico;
        
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
            System.Uri resourceLocater = new System.Uri("/Clinica medica polanco;component/entregarexamen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\entregarExamen.xaml"
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
            this.txt_Entrega_Examen_Buscar = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.btn_Entrega_Examen_Buscar = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.dtg_Entrega_Examen_Examenes = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.btn_Entrega_Examen_Salir = ((System.Windows.Controls.Button)(target));
            
            #line 180 "..\..\..\entregarExamen.xaml"
            this.btn_Entrega_Examen_Salir.Click += new System.Windows.RoutedEventHandler(this.btn_Revision_Examen_Salir_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_Entrega_Examen_Correo = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.btn_Entrega_Examen_Fisico = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

