﻿#pragma checksum "..\..\..\consultarExamen.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "53A1E7BA45031D0FB8091825ED0471A036BD65DC"
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
    /// consultarExamen
    /// </summary>
    public partial class consultarExamen : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 173 "..\..\..\consultarExamen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Consulta_Examen_Buscar;
        
        #line default
        #line hidden
        
        
        #line 174 "..\..\..\consultarExamen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Consulta_Examen_Buscar;
        
        #line default
        #line hidden
        
        
        #line 175 "..\..\..\consultarExamen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtg_Consulta_Examen_Examenes;
        
        #line default
        #line hidden
        
        
        #line 176 "..\..\..\consultarExamen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Consulta_Examen_Salir;
        
        #line default
        #line hidden
        
        
        #line 181 "..\..\..\consultarExamen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Consulta_Examen_Sucursal;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.14.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Clinica medica polanco;component/consultarexamen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\consultarExamen.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.14.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txt_Consulta_Examen_Buscar = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.btn_Consulta_Examen_Buscar = ((System.Windows.Controls.Button)(target));
            
            #line 174 "..\..\..\consultarExamen.xaml"
            this.btn_Consulta_Examen_Buscar.Click += new System.Windows.RoutedEventHandler(this.btn_Consulta_Examen_Buscar_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.dtg_Consulta_Examen_Examenes = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.btn_Consulta_Examen_Salir = ((System.Windows.Controls.Button)(target));
            
            #line 176 "..\..\..\consultarExamen.xaml"
            this.btn_Consulta_Examen_Salir.Click += new System.Windows.RoutedEventHandler(this.btn_Consulta_Examen_Salir_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_Consulta_Examen_Sucursal = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

