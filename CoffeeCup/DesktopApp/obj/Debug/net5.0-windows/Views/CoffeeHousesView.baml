   M S B A M L   `   `   `  ����E  ADesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DesktopApp.ViewsDesktopApp.Views  5      '    !DesktopApp.Views.CoffeeHousesView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:DesktopApp.Views     5        N� Title$  CoffeeHousesView��5	       N� 
Background 5
      �� 5   
    j� Stretch$ UniformToFill=�6    �� ImageSource$F @D:\KursachCoffeCup\CoffeeCup\DesktopApp\Resurses\listcoffee3.jpg��6-   .��5      � -   5         � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��0.8* �6   .+�5   
   �� -   5         ��Name$ listOfCoffeeHouses��5      ��6.   �� *CoffeeHouses+ �� SelectedItem 5      �� *SelectedCoffeeHouse+��5      �� 5      .R�5      �� $��5q�6!   .+�5      �� 
�������$��14(�67   ��6E   ��  �� Path$
 Name��� 5      
���������67   �� $ Address�5      5      5      �� 5   
   $��1��6    � DataContext 6%   �� *SelectedCoffeeHouse+.+�5       �� 
���������6,   �� *Name+	 �� UpdateSourceTrigger$	 PropertyChanged=��� 5!      
���������6,   �� *	Address+$	 PropertyChanged=��� 5"      ��6   �� $ CoffeeItems���5#      �� 5$      .R�5%      �� .+�5&      �� 
���������6;   �� *Name+�� 5'      
���������6;   �� *Price+�� 5(      
 ��Name$
 btnStampDuplicate��6%   -   5        $��Активировать��5(   @   ���	#FF222222$��20, 20, 20, 20 q�6p   $��45��6�   $��1 1 1 1q�6�   ���	#FF222222
 � Tag 6�   �� *Id+6�   5*      5+      5.      �� 5/      -   5        $,��&Добавить в избранное��5/      ���	#FF222222$��20, 20, 20, 20 q�6M   ���	#FF222222$��45��6�   52      54      55      