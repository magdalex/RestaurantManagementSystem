﻿#pragma checksum "..\..\..\ORDERPAGE.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "20CED7DB59D73DD082B4ABD6C10788DBDB877D5D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using RMSWPF;
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


namespace RMSWPF {
    
    
    /// <summary>
    /// CHECKOUTPAGE
    /// </summary>
    public partial class CHECKOUTPAGE : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\ORDERPAGE.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button debitButton;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\ORDERPAGE.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button creditButton;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\ORDERPAGE.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cashButton;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\ORDERPAGE.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button calculateButton;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\ORDERPAGE.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backButton;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\ORDERPAGE.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox orderForBox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\ORDERPAGE.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox priceBeforeTipBox;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\ORDERPAGE.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tipBox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\ORDERPAGE.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox finalPriceBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/RMSWPF;component/orderpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ORDERPAGE.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.debitButton = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\..\ORDERPAGE.xaml"
            this.debitButton.Click += new System.Windows.RoutedEventHandler(this.debitButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.creditButton = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\ORDERPAGE.xaml"
            this.creditButton.Click += new System.Windows.RoutedEventHandler(this.creditButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cashButton = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\ORDERPAGE.xaml"
            this.cashButton.Click += new System.Windows.RoutedEventHandler(this.cashButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.calculateButton = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\ORDERPAGE.xaml"
            this.calculateButton.Click += new System.Windows.RoutedEventHandler(this.calculateButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.backButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\ORDERPAGE.xaml"
            this.backButton.Click += new System.Windows.RoutedEventHandler(this.backButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.orderForBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.priceBeforeTipBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.tipBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.finalPriceBox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

