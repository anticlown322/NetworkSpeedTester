   M S B A M L   `   `   `  ����M  INetworkSpeedTester, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:NetworkSpeedTester.ComponentsNetworkSpeedTester.Components  5      7    1NetworkSpeedTester.Components.InternetSpeedometer   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:NetworkSpeedTester.Components     5      .��5
      �� .+�5   
   F� -   5          F�Name$  backgroundPath��5         SecondaryColor_Solid#��[  5       J� RenderTransformOrigin$ 0.5, 0.5&�5      z�5      �� 5       �� Angle$ 0Q�6"   ��5      B� 5      .��5      E�  E� 
StartPoint$ 100, 465&�6!    E� IsClosed .  ��5      @� �� 5   "    �� Point$ 400, 465&�6-    �� Size$ 250, 250��5   -    �� SweepDirection$ 	Clockwise=�5   -    �� 
IsLargeArc . 	 �� RotationAngle$	 0Q�5   -   �� 5   "   
 �� Point$
 380,445&�6.   �� 5!   "   $ 120,445&�6-   $ 220,220��5"   -   $ Counterclockwise=�5#   -    . $	 0Q�5%   -   �� 5'   "   $
 120,445&�6.   5(      5*      5+      5-      �� 52   
   -   5         ��Name$ 
needleLine��52      
������$��10��54      	 �� X1$	 250��55      	 �� Y1$	 275��6   	 �� X2$	 125��56      	 �� Y2$	 425��6   $y�Visible=�57      � 59   
    � ColumnDefinitions 5:      �� 5;      $	��175 �6#   �� 5<      $	��150 �6#   �� 5=      $	��175 �6#    � RowDefinitions 5?      �� 5@      $	��200 �6    �� 5A      $	��100 �6    �� 5B      $	��200 �6    .+�5F      �� $��1��6   $��1��5G      $��Center=�5H      $��Center=�5I      $��0 0 0 10q�5J      $��24(�5L      $
��Bold"�5M      
���������5K      �� *	CurrValue+ �� RelativeSource ��  �� AncestorType$ UserControlL�5N      �� 5Q      $��2��6   $��1��5R      $��Center=�5S      $��Center=�5T      $��0 50 0 0q�5U      $��24(�5W      
���������5V      �� *
Percentage+ �� $ UserControlL�5X      5Y      5Z      5[      