   M S B A M L   `   `   `  ����C  ?SemPrace, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SemPrace.ViewSemPrace.View  5   	   #    SemPrace.View.DialogOsobaEdit   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:SemPrace.View     5   	     � Title$  DialogOsobaAdd��5      $	��250��6'   $	��300��64    � WindowStyle$ 
ToolWindow=�6@    � WindowStartupLocation$ CenterScreen=�6Y   .��5	      � -   5         �Name$
 grid��5	      $	��300��6   $��Center=�6%   $	��250��6B   $	��Top=�6O    � ColumnDefinitions 5
   
   �� 5      .+�5   
   �� $��Jméno:��6   $��0��6!   $��Right=�6.   $	��Top=�6J   $��
0,43,122,0q�6b   $��26��6v   $��47��6�   �� 5   
   -   5         ��Name$ JmenoTextBox��5      $��0��6(   $��	75,69,0,0q�65   $
��Left=�6H   $	��156��6c   $	��Top=�6o   $��18��6�   $��0,0,0,1q�6�   ��6�   �� *Jmeno+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   $��Příjmení:��6   $��Right=�6$   $	��Top=�6@   $��
0,95,118,0q�6X   $��26��6l   $��56��6x   �� 5   
   -   5        $ PrijmeniTextBox��5      $��
75,121,0,0q�6+   $
��Left=�6?   $	��156��6Z   $	��Top=�6f   $��18��6�   $��0,0,0,1q�6�   ��6   �� *
Prijmeni+$ PropertyChanged=�6�   �� 5   
   -   5         ��Name$ ConfirmButton��5      $��Potvrdit��6(   $
��Left=�6;   $��170,158,0,62q�6V   $��60��6l    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��0,0,0,0q�6�   $��30��6�   ���	#FFC5DEA3��6w   �� *ConfirmCommand+z�5      V� 5      .~�5      �� �� 5      �� 5      	 �� Angle$	 -0.093Q�6&   T� 5      5      5      �� 5   
   -   5        $ CancelButton��5      $��Zrušit��6'   $��Right=�68   $��0,159,165,61q�6T   $��60��6j   $��0,0,0,0q�6�   $��30��6�   ���	#FFF5C3C3��6u   �� *CancelCommand+6�   5       5!      