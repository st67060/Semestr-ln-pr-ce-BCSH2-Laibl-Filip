   M S B A M L   `   `   `  ����C  ?SemPrace, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SemPrace.ViewSemPrace.View  5   	   %    SemPrace.View.DialogVypujckaAdd   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:SemPrace.View     5   	     � Title$  DialogVypujckaPridat��5      $	��559��6.   $	��708��6;    � WindowStyle$ 
ToolWindow=�6G    � WindowStartupLocation$ CenterScreen=�6`   .��5
      � -   5         �Name$
 grid��5
      $	��700��6   $	��500��6%   $��Center=�62   $��0,0,0,21q�6O   $��Bottom=�6a   .+�5   
   �� -   5         ��Name$ listViewOsoba��5      $	��280��6o   $	��500��6{    J� RenderTransformOrigin$ 0.136,0.495&�6�   $��
10,0,410,0q�6�   ���	#FFC5C3C3��6*   �� *Osoby+ �� SelectedItem 6H   �� *SelectedOsoba+ �� View 5      �� 5      .P�5      �� $��
Přijmení��6%    �� Width$ 90��6a   	 �� DisplayMemberBinding	 67   �� *
Prijmeni+6a   �� 5      $��Jméno��6%   $ 90��6[   	 64   �� *Jmeno+6[   �� 5      $��UzivatelskeCislo��6%   $	 100��6q   	 6?   �� *UzivatelskeCislo+6q   5      5      &   System.Windows.Controls.Calendar  5   
   -   5        
  Name$
 
calendarIn��5      $
��Left=�6'   $��
295,82,0,0q�6B   $	��Top=�6V   $	��180��6n   $	��180��6z      SelectedDate 6�   �� *	StartDate+ �� Mode$ TwoWay=�5        5   
   -   5        $
 calendarOut��5      $
��Left=�6(   $��
497,82,0,0q�6C   $	��Top=�6W   $	��180��6o   $	��180��6{    6�   �� *	EndDate+$ TwoWay=��� 5   
   $��Vyberte datum začátku��6   $
��Left=�60   $��
319,54,0,0q�6K   $	��Top=�6_   $��14(�6w   �� 5   
   $��Vyberte datum konce��6   $
��Left=�6.   $��
525,54,0,0q�6I   $	��Top=�6]   $��14(�6u   �� 5   
   -   5         ��Name$ cancelButton��5      $��Zrušit��6'   $
��Left=�68   $��326,441,0,0q�6S   $	��Top=�6h   $��30��6�   $	��125��6�   ���	#FFF5C3C3$��0,0,0,0q�6�   $
��Bold"�6�   ��6�   �� *CancelCommand+6�   �� 5   
   -   5        $ confirmButton��5      $��Potvrdit��6(   $
��Left=�6;   $��525,440,0,0q�6V   $	��Top=�6k   $��30��6�   $	��125��6�   ���	#FFC5DEA3$��0,0,0,0q�6�   $
��Bold"�6�   ��6�   �� *ConfirmCommand+6�   �� 5   
   -   5         ��Name$ textBlockIn��5      $
��Left=�6)   $��350,267,0,0q�6D   $
��Wrap=�6Y   $��	TextBlock��6m   $	��Top=�6~   $	��101��6�   $��25��6�   $��16(�6�   �� 5    
   -   5        $ textBlockOut��5       $
��Left=�6*   $��551,267,0,0q�6E   $
��Wrap=�6Z   $��	TextBlock��6n   $	��Top=�6   $��99��6�   $��25��6�   $��16(�6�   5"       � 	Resources 5#      5  /System.Windows.Controls.Primitives.CalendarItem �� 
TargetType �� Property �� Value:  4System.Windows.Controls.Primitives.CalendarDayButton �� Triggers P� Property P� Value��%B  '        '  p     �� 5$   
   "  6   .�5%      ��  � ��
 ���� 6+   �� 5&       � ��
 ���� 6,   5'      �� 5(   
   "  6   .�5)      ��  � ��
 ���� 6+   �� 5*       � ��
 ���� 6,   �� 5+       � �� �#3333336+    5,      P� 5-       �@ IsToday$
 True��6-   . �5.      ��  � �� �#2196F363   �� 5/       � ��
 �����63   50      P� 51       �@ 
IsSelected$
 True��60   . �52      ��  � �� �#FF525263   �� 53       � ��
 �����63   54      56      57      58      