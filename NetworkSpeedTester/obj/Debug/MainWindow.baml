   M S B A M L   `   `   `  ����M  INetworkSpeedTester, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:NetworkSpeedTesterNetworkSpeedTester  5   	   W0clr-namespace:NetworkSpeedTester.MVVM.ViewModels"NetworkSpeedTester.MVVM.ViewModels  5   	   #    NetworkSpeedTester.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:NetworkSpeedTester     5   	   G
viewModels0clr-namespace:NetworkSpeedTester.MVVM.ViewModels     5   	   -   5        $��wndMain��5   	   $	��720��5	   	   $
��1350��5
   	     � WindowStyle$
  None=�5   	    � 
ResizeMode$ NoResize=�5   	    � AllowsTransparency . 
������  � WindowStartupLocation$ CenterScreen=�5   	    � DataContext 5      6  0NetworkSpeedTester.MVVM.ViewModels.MainViewModel  5   
    J� InputBindings 5      �� 5   
   
 �� Key$	 Esc��5       �� Command 5      �� *CloseWindowCommand+ �� CommandParameter 5      �� 	 �� ElementName$	 wndMain��5      �� 5   
   
 �� Gesture$
 Ctrl+M��5       5      �� *MinimizeWindowCommand+ 5      �� $	 wndMain��5      .��5!      �� -   5         �� CornerRadius$ 20��5!      $��1q�5"       J� Opacity$
 0.97Q�5#      ��5%   
   �� 5&       �� 
StartPoint$
 0, 0&�6"    �� EndPoint$
 1, 1&�64   .��5'      �    WindowBorderColor1 � Color# [  6    � Offset$ 0Q�6K   � 5(        WindowBorderColor2# [ 6   $	 0.5Q�6K   � 5)        WindowBorderColor3# [ 6   $ 1Q�6K   5*      ��5,   
   �� 5-      $
 0, 0&�6"   $ 1, 0.7&�64   .��5.      �   PrimaryColorLight# [ 6   $ 0Q�6J   � 5/        PrimaryColorDark# [ 6   $ 1Q�6I   50      ._�54   
   �  � RowDefinitions 55      �� 56      $��50 �6    �� 57      $��* �6     � ColumnDefinitions 59      �� 5:      $	��200 �6#   �� 5;      $��* �6#   .+�5?      �� -   5        $��1��5?      $��0��5@       �� Orientation$ 
Horizontal=�5B      $��RightToLeft=�5C      $��	10 0 10 0q�5D      .+�5E      ��   TopMenuButtonTheme#��[ 5G        CloseWindow#��[ 5H      ��5E      �� *CloseWindowCommand+��5F      �� $	 wndMain��5H      �� 5I      #��[ 5K        MinimizeWindow#��[ 5L      ��5I      �� *MinimizeWindowCommand+��5J      �� $	 wndMain��5L      5M      �� 5P      $��0��6   $��0��5Q      $��2��5R      $ 	20 0 0 20��5S        PrimaryColorDark_Solid#��[ 5T      ._�5U      �� .+�5V      �� $��0��6    $��0��5W       $
��Left=�5X       $��Center=�5Y        	 MenuTextColorLight_Solid#��[	 5Z       $��24(�5[       $��Century Gothic)�5\       $��Italic$�5]       $
��Bold"�5^       $��
30,10,0,10q�5_       	Anticlown5a      	� 5b      $��Tester��6"    
 LeftMenuButtonTheme#��[
 5c       d� 	IsChecked$
 TrueY�5d      ��5e      �� *TesterViewCommand+	� 5g      $
��Help��6"   #��[
 5h      ��5i      �� *HelpViewCommand+	� 5k      $��Settings��6"   #��[
 5l      ��5m      �� *SettingsViewCommand+	� 5o      $��About��6"   #��[
 5p      ��5q      �� *AboutViewCommand+5r      5s      �� 5v      $��1��6   $��1��5w      $��10q�5x      ��5y      �� *CurrentView+5z      5{      5|      5}      