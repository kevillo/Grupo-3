﻿#pragma checksum "..\..\..\menuPrincipalExamenes.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "34CFD8B27E8D8DF1B8372D7D8DD0C3BA4B9CF389"
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
    /// menuPrincipalExamenes
    /// </summary>
    public partial class menuPrincipalExamenes : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 68 "..\..\..\menuPrincipalExamenes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Nuevo_Examen;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\menuPrincipalExamenes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Entregar_Examen;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\menuPrincipalExamenes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Consultar_Examen;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\menuPrincipalExamenes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Analizar_Examen;
        
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
            System.Uri resourceLocater = new System.Uri("/Clinica medica polanco;component/menuprincipalexamenes.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\menuPrincipalExamenes.xaml"
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
            this.btn_Nuevo_Examen = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\menuPrincipalExamenes.xaml"
            this.btn_Nuevo_Examen.Click += new System.Windows.RoutedEventHandler(this.btn_Nuevo_Examen_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_Entregar_Examen = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.btn_Consultar_Examen = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\menuPrincipalExamenes.xaml"
            this.btn_Consultar_Examen.Click += new System.Windows.RoutedEventHandler(this.btn_Consultar_Examen_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_Analizar_Examen = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

