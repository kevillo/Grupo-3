﻿#pragma checksum "..\..\..\ConsultarEmpleados.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "56CA8DE86F9AB98A00D812976030C20EEB6B4251"
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
    /// ConsultarEmpleados
    /// </summary>
    public partial class ConsultarEmpleados : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 121 "..\..\..\ConsultarEmpleados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Consultar_Empleados_Buscar;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\ConsultarEmpleados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Consultar_Empleados_Buscar;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\ConsultarEmpleados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtg_Consultar_Empleados;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\ConsultarEmpleados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Consultar_Empleados_Salir;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Clinica medica polanco;component/consultarempleados.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ConsultarEmpleados.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txt_Consultar_Empleados_Buscar = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.btn_Consultar_Empleados_Buscar = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.dtg_Consultar_Empleados = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.btn_Consultar_Empleados_Salir = ((System.Windows.Controls.Button)(target));
            
            #line 124 "..\..\..\ConsultarEmpleados.xaml"
            this.btn_Consultar_Empleados_Salir.Click += new System.Windows.RoutedEventHandler(this.btn_ConsultarEmpleados_Salir_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

