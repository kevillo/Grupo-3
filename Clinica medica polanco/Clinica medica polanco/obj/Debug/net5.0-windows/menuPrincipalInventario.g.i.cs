﻿#pragma checksum "..\..\..\menuPrincipalInventario.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AD64862B89E99446A4F59AD036F01641BBD03D0D"
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
    /// menuPrincipalInventario
    /// </summary>
    public partial class menuPrincipalInventario : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 232 "..\..\..\menuPrincipalInventario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Gestionar_Insumos;
        
        #line default
        #line hidden
        
        
        #line 233 "..\..\..\menuPrincipalInventario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Ver_Compras;
        
        #line default
        #line hidden
        
        
        #line 234 "..\..\..\menuPrincipalInventario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Ver_Ventas;
        
        #line default
        #line hidden
        
        
        #line 235 "..\..\..\menuPrincipalInventario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Gestionar_Proveedores;
        
        #line default
        #line hidden
        
        
        #line 236 "..\..\..\menuPrincipalInventario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Actualizar_Stock;
        
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
            System.Uri resourceLocater = new System.Uri("/Clinica medica polanco;V1.0.0.0;component/menuprincipalinventario.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\menuPrincipalInventario.xaml"
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
            this.btn_Gestionar_Insumos = ((System.Windows.Controls.Button)(target));
            
            #line 232 "..\..\..\menuPrincipalInventario.xaml"
            this.btn_Gestionar_Insumos.Click += new System.Windows.RoutedEventHandler(this.btn_Gestionar_Insumos_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_Ver_Compras = ((System.Windows.Controls.Button)(target));
            
            #line 233 "..\..\..\menuPrincipalInventario.xaml"
            this.btn_Ver_Compras.Click += new System.Windows.RoutedEventHandler(this.btn_Ver_Compras_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_Ver_Ventas = ((System.Windows.Controls.Button)(target));
            
            #line 234 "..\..\..\menuPrincipalInventario.xaml"
            this.btn_Ver_Ventas.Click += new System.Windows.RoutedEventHandler(this.btn_Ver_Ventas_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_Gestionar_Proveedores = ((System.Windows.Controls.Button)(target));
            
            #line 235 "..\..\..\menuPrincipalInventario.xaml"
            this.btn_Gestionar_Proveedores.Click += new System.Windows.RoutedEventHandler(this.btn_Gestionar_Proveedores_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_Actualizar_Stock = ((System.Windows.Controls.Button)(target));
            
            #line 236 "..\..\..\menuPrincipalInventario.xaml"
            this.btn_Actualizar_Stock.Click += new System.Windows.RoutedEventHandler(this.btn_Actualizar_Stock_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

