   M S B A M L   `   `   `  ����E  ADesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DesktopApp.ViewsDesktopApp.Views  5   	   +    %DesktopApp.Views.RegWindowCoffeeHouse   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   *localclr-namespace:DesktopApp.Views  5   	   -   5          � Title$  RegWindowCoffeeHouse��5	   	   $	��420��6'   $	��730��64    � AllowsTransparency$
 True��6@    � WindowStyle$
 None=�6Z    � WindowStartupLocation$ CenterScreen=�6m   ��5
      �� 5   
    �� ImageSource$@ :D:\KursachCoffeCup\CoffeeCup\DesktopApp\Resurses\BgReg.png��6   .��5      � -   5         � RowDefinitions 5   
   �� 5      $	��10* �6   �� 5      $	��11* �6   �� 5      $	��15* �6   �� 5      $	��13* �6   �� 5      $	��31* �6   �� 5      $��4* �6    � ColumnDefinitions 5   
   �� 5      $
��210* �6   �� 5      $
��155* �6   �� 5      $
��183* �6   �� 5      $
��183* �6   .+�5   
   �� $��Registration��6   $
��Left=�6'   
�������$��40��6U   $��25,0,0,0q�6a   $��Center=�6s   $	��150��6�   $
��Bold"�6�   $��22(�6�   $��0��6�   $��2��6�   �� 5   
   -   5         ��Name$ UserName��5      $��15(�6$   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$  Логин��62   $��0 q�6Z    %  !MaterialDesignFloatingHintTextBox#��[  6g   
�������$��
14,0,19,22q�6�   $��3��6�   �� 5    
   -   5        $ Password��5       $��15(�6$   $  Пароль��62   $��0 q�6[   #��[  6h   
�������$��
14,0,4,115q�6�   $��4��6�   �� 5!   
   -   5        	 ��Name$	 	CheckBox1��5!      $2��,Являетесь предприятием?��6&   $
��Left=�6H   $��	14,59,0,0q�6c   
�������$��4��6�   $	��Top=�6�   $	��168��6�   $��18��6�   �� 5%   
   -   5        $*��$Зарегистрироваться��5%      $��Center=�6.   $��	0,100,0,0q�6K   $	��Top=�6^   $	��185��6v   $��35��6�   ���	#FF352633$��4��6�   �� 5&   
   -   5        $$��Уже есть аккаунт��5&      
�������$
��Left=�6>   $��
65,140,0,0q�6Y   $	��Top=�6m   $	��110��6�   $��25��6�   
 � Cursor$

 Help��6�   $��2��6�   $��4��6�   �� 5'   
   -   5        $��X��5'      $	��Top=�6   $
 Exit��64   $
��Left=�6Z   $��30��6u   $��	158,0,0,0q�6�   $��7 0 1 0 q�6�    � ForceCursor$
 True��6�   $��20(�6�   
�������$��24��6�   $

 Hand��6  $��3��6   5)      5*      