   M S B A M L   `   `   `  ����M  INetworkSpeedTester, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:NetworkSpeedTester.MVVM.ViewModels"NetworkSpeedTester.MVVM.ViewModels  5      M+clr-namespace:NetworkSpeedTester.ComponentsNetworkSpeedTester.Components  5      .    (NetworkSpeedTester.MVVM.Views.TesterView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      G
viewModels0clr-namespace:NetworkSpeedTester.MVVM.ViewModels     5      B
components+clr-namespace:NetworkSpeedTester.Components     5      .��5      �   � RowDefinitions  5   
   �� 5      $��10 �6   �� 5      $��50 �6   �� 5      $	��150 �6   �� 5      $	��200 �6   �� 5      $	��150 �6   �� 5      $��50 �6   �� 5      $��40 �6    � ColumnDefinitions 5   
   �� 5      $	��300 �6   �� 5      $	��530 �6   �� 5      $	��300 �6   .+�5   
   �� $��0��6   $��1��5      $��5��5      $��10 10 10 10q�5        �� CornerRadius$ 20��5!         SecondaryColor_Solid#��[  5"      ._�5#      ��  � DataContext 6   �� *Tester+.+�5%      �� $��Center=�6   $��	0 10 0 10q�5&      $��24(�5'      $
��Bold"�5(      
�������$��General Info��5*      �� 5-      $
��Left=�6   $��10 5 0 5q�5.      $��20(�5/      
�������$��
Public IP:��51      �� 52      $
��Left=�6   $��10 5 0 5q�53      $��20(�54      $
��Bold"�55      
���������57      �� *
PublicIP+�� 5:      $
��Left=�6   $��10 5 0 5q�5;      $��20(�5<      
�������$��Company:��5>      �� 5?      $
��Left=�6   $��10 5 0 5q�5@      $	��200��5A      $
��Wrap=�5B      $��20(�5C      $
��Bold"�5D      
���������5F      �� *IpCompanyName+�� 5I      $
��Left=�6   $��10 5 0 5q�5J      $��20(�5K      
�������$��	Location:��5M      �� 5N      $
��Left=�6   $��10 5 0 5q�5O      $��20(�5P      $
��Bold"�5Q      
���������5S      �� *
IpLocation+�� 5V      $
��Left=�6   $��10 5 0 5q�5W      $��20(�5X      
�������$��Country:��5Z      �� 5[      $
��Left=�6   $��10 5 0 5q�5\      $��20(�5]      $
��Bold"�5^      
���������5`      �� *IpCountryName+�� 5c      $
��Left=�6   $��10 5 0 5q�5d      $��20(�5e      
�������$��City:��5g      �� 5h      $
��Left=�6   $��10 5 0 5q�5i      $��20(�5j      $
��Bold"�5k      
���������5m      �� *
IpCityName+5n      5o      7   1NetworkSpeedTester.Components.InternetSpeedometer  5r   
   $��1��6)   $��2��5s   )   $��3��5t   )   $��	15 0 15 0q�5u   )    5v   )   �� *Tester+   	CurrValue 5w   )   �� *CurrentValue+   
Percentage 5x   )   �� *CurrentPercentage+�� 5z   
   $��1��6   $��5��5{      $	��100��5|      ��5}      �� *StartTestCommand+3   -NetworkSpeedTester.Components.TestResultBlock  5�   
   $��2��6%   $��1��5�   %   $��2��5�   %   $��10 10 10 10q�5�   %      Title$ Download��5�   %      	ParamIcon$) #../../Resources/Images/download.png��5�   %      Units$
 Mbps��5�   %    5�   %   �� *Tester+	   	AverValue	 5�   %   �� *AverSpeedDownload+
   MaxValue
 5�   %   �� *MaxSpeedDownload+5�   %     5�   
   $��2��6%   $��3��5�   %   $��10 10 10 10q�5�   %   $ Upload��5�   %   $' !../../Resources/Images/upload.png��5�   %   $
 Mbps��5�   %    5�   %   �� *Tester+	 5�   %   �� *AverSpeedUpload+
 5�   %   �� *MaxSpeedUpload+5�   %     5�   
   $��2��6%   $��4��5�   %   $��2��5�   %   $��10 10 10 10q�5�   %   $
 Ping��5�   %   $% ../../Resources/Images/ping.png��5�   %   $ ms��5�   %    5�   %   �� *Tester+	 5�   %   �� *
AverPing+
 5�   %   �� *	MaxPing+5�   %   5�      5�      