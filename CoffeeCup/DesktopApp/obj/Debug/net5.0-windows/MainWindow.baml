   M S B A M L   `   `   `  ����E  ADesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:DesktopApp
DesktopApp  5   	       DesktopApp.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:DesktopApp     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   -   5          � Title$  
MainWindow��5	   	   $	��420��6   $	��730��6)    � AllowsTransparency$
 True��65    � WindowStyle$
 None=�6O    � WindowStartupLocation$ CenterScreen=�6b   ��5
      �� 5   
    �� ImageSource$C =D:\KursachCoffeCup\CoffeeCup\DesktopApp\Resurses\BgRegLog.png��6   .��5      � -   5         � RowDefinitions 5   
   �� 5      $	��14* �6   �� 5      $��9* �6   �� 5      $	��16* �6   �� 5      $	��24* �6   �� 5      $	��12* �6   �� 5      $��9* �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5         ��Name$ TextFieldLogin��5      $��0��6(   $��2��68   $��Login��6F   $
��Left=�6V   $��40��6q   $��	20,15,0,0q�6}   $	��Top=�6�   $��70��6�   
�������$��Segoe UI Emoji)�6�   $��22(�6�   $
��Bold"�6�   �� 5   
   $]��WДобро пожаловать, войдите в свою учётную запись��6   $
��Left=�6J   $��24��6e   $��	20,50,0,0q�6q   $	��Top=�6�   $	��250��6�   $��10(�6�   
�������$��2��6�   $��2��6�   �� 5   
   $��Label��6   $
��Left=�6    $��5��6;   $��	23,72,0,0q�6F   $	��Top=�6Y   $��87��6q   ���	#FFFA6F7C$��2��6�   $��0��6�   �� 5#   
    �� Orientation$ 
Horizontal=�6   $
��Left=�6.   $��55��6I   $	��Top=�6U   $	��178��6m   $��4,77,0,0q�6y   $��2��6�   $��2��6�   .+�5$      '  !MaterialDesignThemes.Wpf.PackIcon  	   Kind$	 Account=�6&   $��20��66   $��20��6A   $��Bottom=�6�   $��5 0 0 4 q�6�   ��6M   �� 
 �� ElementName$
 UserName�� �� Path$ BorderBrush�6�   �� 5%      -   5         ��Name$ UserName��5%      $��15(�6(   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	 Username��66   $��0 q�6a    %  !MaterialDesignFloatingHintTextBox#��[  6n   
�������$��0,15,0,5q�6�   $	��121��6�   5&      �� 5(   
   $ 
Horizontal=�6   $	��Top=�6.   $��95��6F    J� RenderTransformOrigin$ 0.5,0.5&�6R   $��4,60,4,0q�6s   $��2��6�   $��3��6�   .+�5)        $��5 19 0 4q�6&   $		 Key=�68   $��20��6C   $��20��6N   G� 5*      -   5         G�Name$ Password��5*      $ Password��6,    # MaterialDesignFilledPasswordBox#��[ 6V   
�������$	��120��6�   $��5q�6�   $��14(�6�   $��0,0,0,55q�6�   �� 5+      $�� ��6   $��9��6   $��0,81,0,0q�6*   $	��Top=�6<   $��81��6T   5,      �� 50   
   -   5        $��
Войти��50      $
��Left=�6!   $��25��6<   $��	35,16,0,0q�6H   $	��Top=�6[   $��96��6s   ���	#FFB66C71$��4��6�   $��0��6�   6�   �� 51   
   -   5        $��X��51      $	��Top=�6   $
 Exit��64   $
��Left=�6Z   $��30��6u   $��	158,0,0,0q�6�   $��7 0 1 0 q�6�    � ForceCursor$
 True��6�   $��20(�6�   
�������$��24��6�    � Cursor$
 Hand��6  $��3��6$  �� 52   
   -   5        $%��Ещё нет аккаунта?��52      $��19��6,   $��8(�69   
�������$	��Top=�6Z   $
 Help��6s   $��4��6�   $��
45,40,52,0q�6�   6�   (  "System.Windows.Controls.WebBrowser  55   
   -	   5          Name$ 
webBrowser��55   D   $y�Hidden=�6   $	��420��6*   $	��265��66    K� ZIndex$
 1000��6y   $��Center=�6�   $��Center=�6�   $��145,95,165,60q�6�   d� 56   
    * &MaterialDesignActionAccentToggleButton#��[ 6    � ToolTip$+ %MaterialDesignActionLightToggleButton��6X   $��35,3,116,10q�6�   ���	#FFFD8589$��5��6�   ��57        58      -
   5        $	 Facebook=�58   *   $��28��6:   ���	#DD002DF96]   5:      d� 5;   
   #��[ 6   $+ %MaterialDesignActionLightToggleButton��6d   $��
83,3,68,10q�6�   ���	#FFFD8589$��5��6�   .��5<        $	 Google=�6&   $��28��64   ���	#DD16C5266@   5=      d� 5>   
   #��[ 6   $+ %MaterialDesignActionLightToggleButton��6d   $��130,3,20,10q�6�   ���	#FFFD8589$��5��6�   .��5?        $	 	Instagram=�6&   $��28��67   ���	#DD8E009C6C   5@      5C      5D      