﻿#pragma checksum "..\..\..\..\Views\CoffeeHouseMainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24B518FC9839CE4DF4BB862811160B5102C71AE8"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using DesktopApp.Views;
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


namespace DesktopApp.Views {
    
    
    /// <summary>
    /// CoffeeHouseMainWindow
    /// </summary>
    public partial class CoffeeHouseMainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\Views\CoffeeHouseMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MyCofebt;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Views\CoffeeHouseMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Statisticbt;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Views\CoffeeHouseMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Popularbt;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Views\CoffeeHouseMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse AddCoffeeHouses;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Views\CoffeeHouseMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame NewAddCompany;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DesktopApp;component/views/coffeehousemainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\CoffeeHouseMainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\..\Views\CoffeeHouseMainWindow.xaml"
            ((DesktopApp.Views.CoffeeHouseMainWindow)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MyCofebt = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.Statisticbt = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\Views\CoffeeHouseMainWindow.xaml"
            this.Statisticbt.Click += new System.Windows.RoutedEventHandler(this.Statisticbt_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Popularbt = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\..\Views\CoffeeHouseMainWindow.xaml"
            this.Popularbt.Click += new System.Windows.RoutedEventHandler(this.Popularbt_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AddCoffeeHouses = ((System.Windows.Shapes.Ellipse)(target));
            
            #line 30 "..\..\..\..\Views\CoffeeHouseMainWindow.xaml"
            this.AddCoffeeHouses.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.AddCoffeeHouses_MouseDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.NewAddCompany = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

