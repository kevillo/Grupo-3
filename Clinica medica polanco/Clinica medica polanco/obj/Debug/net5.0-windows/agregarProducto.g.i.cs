﻿#pragma checksum "..\..\..\agregarProducto.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9C0E2F42259C2ED607C6F47F407B5DAB8AAB3578"
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
    /// agregarProducto
    /// </summary>
    public partial class agregarProducto : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 67 "..\..\..\agregarProducto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle txt_Nombre_p;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\agregarProducto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Proveedor_Olvidado;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\agregarProducto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Nombre_Producto;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\agregarProducto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Numero_Serie;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\agregarProducto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Precio_Unitario;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\agregarProducto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmb_Tipo_Insumo;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\agregarProducto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmb_Nombre_Insumo;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\agregarProducto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtp_Fecha_Expiracion;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\agregarProducto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chb_Disponibilidad;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\agregarProducto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Agregar_Producto;
        
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
            System.Uri resourceLocater = new System.Uri("/Clinica medica polanco;V1.0.0.0;component/agregarproducto.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\agregarProducto.xaml"
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
            this.txt_Nombre_p = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 2:
            this.btn_Proveedor_Olvidado = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\..\agregarProducto.xaml"
            this.btn_Proveedor_Olvidado.Click += new System.Windows.RoutedEventHandler(this.btn_Proveedor_Olvidado_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txt_Nombre_Producto = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txt_Numero_Serie = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txt_Precio_Unitario = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.cmb_Tipo_Insumo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.cmb_Nombre_Insumo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.dtp_Fecha_Expiracion = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 9:
            this.chb_Disponibilidad = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 10:
            this.btn_Agregar_Producto = ((System.Windows.Controls.Button)(target));
            
            #line 92 "..\..\..\agregarProducto.xaml"
            this.btn_Agregar_Producto.Click += new System.Windows.RoutedEventHandler(this.btn_Agregar_Producto_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

