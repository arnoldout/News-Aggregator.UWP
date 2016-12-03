﻿#pragma checksum "C:\Users\Olivr\College\Mobile Programming\NwsAggregatorFrontEnd\NewsAggregator\Feed.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "346DAA94FC457C1EADB1A3D693FC5028"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewsAggregator
{
    partial class Feed : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        internal class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_ProgressRing_IsActive(global::Windows.UI.Xaml.Controls.ProgressRing obj, global::System.Boolean value)
            {
                obj.IsActive = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Windows.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
        };

        private class Feed_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IFeed_Bindings
        {
            private global::NewsAggregator.Feed dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.ProgressRing obj2;
            private global::Windows.UI.Xaml.Controls.TextBlock obj3;
            private global::Windows.UI.Xaml.Controls.ListView obj4;

            private Feed_obj1_BindingsTracking bindingsTracking;

            public Feed_obj1_Bindings()
            {
                this.bindingsTracking = new Feed_obj1_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2:
                        this.obj2 = (global::Windows.UI.Xaml.Controls.ProgressRing)target;
                        (this.obj2).RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.ProgressRing.IsActiveProperty,
                            (global::Windows.UI.Xaml.DependencyObject sender, global::Windows.UI.Xaml.DependencyProperty prop) =>
                            {
                                if (this.initialized)
                                {
                                    // Update Two Way binding
                                    this.dataRoot.nwsPaper.IsActive = (this.obj2).IsActive;
                                }
                            });
                        break;
                    case 3:
                        this.obj3 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 4:
                        this.obj4 = (global::Windows.UI.Xaml.Controls.ListView)target;
                        break;
                    default:
                        break;
                }
            }

            // IFeed_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            // Feed_obj1_Bindings

            public void SetDataRoot(global::NewsAggregator.Feed newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.dataRoot = newDataRoot;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::NewsAggregator.Feed obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_nwsPaper(obj.nwsPaper, phase);
                    }
                }
            }
            private void Update_nwsPaper(global::NewsAggregator.ViewModels.NwsFeedViewModel obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_nwsPaper(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_nwsPaper_IsActive(obj.IsActive, phase);
                        this.Update_nwsPaper_DefText(obj.DefText, phase);
                        this.Update_nwsPaper_StoryCollection(obj.StoryCollection, phase);
                    }
                }
            }
            private void Update_nwsPaper_IsActive(global::System.Boolean obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ProgressRing_IsActive(this.obj2, obj);
                }
            }
            private void Update_nwsPaper_DefText(global::System.String obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj3, obj, null);
                }
            }
            private void Update_nwsPaper_StoryCollection(global::System.Collections.ObjectModel.ObservableCollection<global::NewsAggregator.ViewModels.StoryViewModel> obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj4, obj, null);
                }
            }

            private class Feed_obj1_BindingsTracking
            {
                global::System.WeakReference<Feed_obj1_Bindings> WeakRefToBindingObj; 

                public Feed_obj1_BindingsTracking(Feed_obj1_Bindings obj)
                {
                    WeakRefToBindingObj = new global::System.WeakReference<Feed_obj1_Bindings>(obj);
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_nwsPaper(null);
                }

                public void PropertyChanged_nwsPaper(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    Feed_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        string propName = e.PropertyName;
                        global::NewsAggregator.ViewModels.NwsFeedViewModel obj = sender as global::NewsAggregator.ViewModels.NwsFeedViewModel;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                    bindings.Update_nwsPaper_IsActive(obj.IsActive, DATA_CHANGED);
                                    bindings.Update_nwsPaper_DefText(obj.DefText, DATA_CHANGED);
                                    bindings.Update_nwsPaper_StoryCollection(obj.StoryCollection, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "IsActive":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_nwsPaper_IsActive(obj.IsActive, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "DefText":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_nwsPaper_DefText(obj.DefText, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "StoryCollection":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_nwsPaper_StoryCollection(obj.StoryCollection, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                private global::NewsAggregator.ViewModels.NwsFeedViewModel cache_nwsPaper = null;
                public void UpdateChildListeners_nwsPaper(global::NewsAggregator.ViewModels.NwsFeedViewModel obj)
                {
                    if (obj != cache_nwsPaper)
                    {
                        if (cache_nwsPaper != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_nwsPaper).PropertyChanged -= PropertyChanged_nwsPaper;
                            cache_nwsPaper = null;
                        }
                        if (obj != null)
                        {
                            cache_nwsPaper = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_nwsPaper;
                        }
                    }
                }
                public void PropertyChanged_nwsPaper_StoryCollection(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    Feed_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        string propName = e.PropertyName;
                        global::System.Collections.ObjectModel.ObservableCollection<global::NewsAggregator.ViewModels.StoryViewModel> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::NewsAggregator.ViewModels.StoryViewModel>;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                        }
                        else
                        {
                            switch (propName)
                            {
                                default:
                                    break;
                            }
                        }
                    }
                }
                public void CollectionChanged_nwsPaper_StoryCollection(object sender, global::System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
                {
                    Feed_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        global::System.Collections.ObjectModel.ObservableCollection<global::NewsAggregator.ViewModels.StoryViewModel> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::NewsAggregator.ViewModels.StoryViewModel>;
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 4:
                {
                    this.lvw = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    #line 38 "..\..\..\Feed.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListView)this.lvw).SelectionChanged += this.lvw_SelectionChanged;
                    #line default
                }
                break;
            case 5:
                {
                    this.settings = (global::Windows.UI.Xaml.Controls.Image)(target);
                    #line 30 "..\..\..\Feed.xaml"
                    ((global::Windows.UI.Xaml.Controls.Image)this.settings).Tapped += this.goToSettings;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    Feed_obj1_Bindings bindings = new Feed_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            }
            return returnValue;
        }
    }
}

