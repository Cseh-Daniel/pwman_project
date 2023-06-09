﻿#pragma checksum "..\..\..\..\Pages\Main.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0A294E1496BAA141E9AF16842BF0DBB84B0B618E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PasswordManager.Pages;
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


namespace PasswordManager.Pages {
    
    
    /// <summary>
    /// MainPage
    /// </summary>
    public partial class MainPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\..\..\Pages\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbDatabaseName;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\Pages\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSearchBar;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\Pages\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel spPasswordList;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PasswordManager;component/pages/main.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Main.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.tbDatabaseName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            
            #line 44 "..\..\..\..\Pages\Main.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.aCopyUsername);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 45 "..\..\..\..\Pages\Main.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.aCopyPassword);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 46 "..\..\..\..\Pages\Main.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.aOpenLink);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 48 "..\..\..\..\Pages\Main.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.aNewEntry);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 49 "..\..\..\..\Pages\Main.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.aEditEntry);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 50 "..\..\..\..\Pages\Main.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.aDeleteEntry);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 52 "..\..\..\..\Pages\Main.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.aLogout);
            
            #line default
            #line hidden
            return;
            case 9:
            this.tbSearchBar = ((System.Windows.Controls.TextBox)(target));
            
            #line 62 "..\..\..\..\Pages\Main.xaml"
            this.tbSearchBar.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.aSearch);
            
            #line default
            #line hidden
            return;
            case 10:
            this.spPasswordList = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

