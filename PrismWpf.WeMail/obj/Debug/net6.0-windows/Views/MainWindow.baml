   M S B A M L   `   `   `  ����J  FPrismWpf.WeMail, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:PrismWpf.WeMailPrismWpf.WeMail  5      Q MPrismWpf.WeMail.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulluOclr-namespace:PrismWpf.WeMail.Common.Converters;assembly=PrismWpf.WeMail.Common!PrismWpf.WeMail.Common.Converters 5
      &     PrismWpf.WeMail.Views.MainWindow   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      /localclr-namespace:PrismWpf.WeMail     5      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5      _	 [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes 	 5	      _	converterOclr-namespace:PrismWpf.WeMail.Common.Converters;assembly=PrismWpf.WeMail.Common 	 5
      $
��1280��5      $	��720��5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5       � WindowStyle$
 None=�5       � AllowsTransparency$
 True��5         MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5      $��微软雅黑)�5       � WindowStartupLocation$ CenterScreen=�5       � Title 5      �� *Title+ � 	Resources 5      9  3PrismWpf.WeMail.Common.Converters.MenuIconConverter  MenuIconConverter��%   &	         5   
   6&   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5       	 � RowDefinitions	 5"   
   �� 5#      $��40 �6   �� 5$      .+�5&   
   �� -   5        $��2��5'        PrimaryHueLightBrush#���  5)      � 5*   
   -   5        
 �Name$
 	GridTitle��5*      $��2��5+      $��Center=�5,      .+�5-      �� $
��Left=�6    �� Orientation$ 
Horizontal=�64   .+�5.      ' 	 !MaterialDesignThemes.Wpf.PackIcon  $��35��5/      $��35��50      $
��10,0q�51      $��Center=�52         Kind$ 	EmailFast=�53      
�������54      �� 55      $��WeMail��56      $��Center=�57      $��	ExtraBold"�58      $��20(�59      
�������5:      5;      �� 5<      $��Right=�6   $ 
Horizontal=�65   .+�5=      ' 	 !MaterialDesignThemes.Wpf.PopupBox     	StaysOpen$
 True��6*   
�������   PopupContent. 5>      �� .+�5?      �� $��设置账号��6!   ��60   �� *LoginCommand+5@      5A      �� 5B      -   5         ��Name$ BtnMin��5B      
������ 
������ ��5C      0 	 *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Minus=�5F      �� 5G      -   5        $ BtnMax��5G      
������ 
������ ��5H        $ 
CropSquare=�5K      �� 5L      -   5        $ BtnClose��5L      
������ 
������ ��5M        $ Close=�5P      5Q      5R      �� 5S   
   $��1��6   ��5T      �� *	Modules+ �� SelectedItem 5U      �� *
ModuleInfo+��5V      �� 5W      .R�5X      �� $ 
Horizontal=�6!   .+�5Y        $��25��5Z      $��25��5[      $
��10,0q�5\      $��Center=�5]       5^      �� *
ModuleName+ �� 	Converter# [ �� 5_      $��Center=�5a      $��15(�5b      $
��Bold"�5c      ��5`      �� *DisplayName+5c      5d      5e      5g      �� 5h   
   $��1��6   $��1��6&   !  Prism.Regions.RegionManager   
RegionName$ ContentRegion��5i      5j      5k      