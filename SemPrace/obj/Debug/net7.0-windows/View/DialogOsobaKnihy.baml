   M S B A M L   `   `   `  ����C  ?SemPrace, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SemPrace.ViewSemPrace.View  5   	   $    SemPrace.View.DialogOsobaKnihy   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:SemPrace.View     5   	     � Title$  DialogOsobaListKnihy��5      $	��601��6.   $	��480��6;    � WindowStyle$ 
ToolWindow=�6G    � WindowStartupLocation$ CenterScreen=�6`   .��5	      � $	��480��6   $	��600��6    � RowDefinitions 5
   
   �� 5      $
��107* �6   �� 5      $
��193* �6   .+�5   
   �� -   5         ��Name$ listViewKniha��5      $��	0,0,0,142q�6H    �� SelectionMode$ Single=�6[    J� RenderTransformOrigin$ 0.5,0.5&�6r   $	��480��6�   $��Center=�6�   $��2��6�   $��0,0,0,0q�6�   ���	#FFF7ECD8$	��456��6�   $��Bottom=�6
  ��6*   �� *Knihy+z�5      V� 5      .~�5      �� �� 5       �� AngleY$ 0.163Q�6$   �� 5      T� 5       T� Y$ 0.573Q�6)   5      	 �� View	 5      �� 5      .P�5      �� $��Název��6%   
 �� Width$
 90��6[    �� DisplayMemberBinding 64   �� *Nazev+6[   �� 5      $��Autor��6%   $	
 100��6[    64   �� *Autor+6[   �� 5      $	��Rok��6%   $
 65��6]    62   �� *	RokVydani+6]   �� 5      $��vypůjčena��6%   $
 60��68    �� CellTemplate 5      �� 5      .R�5   "   �� ��5    &   �� 5!   *    �� 
TargetType" ��60    �� Triggers 5"   .   �� 5#   2    �� Binding 6>   �� *	Vypujceni+ �� Value True6\   .a�5$   6   ��  �� Property � �� �� Value$	 Ano��6M   5%   3   �� 5&   2    6>   �� *	Vypujceni+	 False6\   .a�5'   6   ��  � ��$ Ne��6M   5(   3   5*   +   5,   #   5-      5/      �� 51      $��Vypůjčení��6%   $
 80��6h    68   �� *DatumVypujceni+6h   �� 52      $��	Vrácení��6%   $
 80��6f    66   �� *DatumNavraceni+6f   53      55      �� 56   
   -   5         ��Name$ ConfirmButton��56      $��Ok��6(   $��Center=�65   $��	0,274,0,0q�6R   $��1��6e   $	��Top=�6r   $��36��6�   $	��120��6�   ���	#FFFBEE99$��0,0,0,0q�6�   ��6�   �� *ConfirmCommand+6�   58      59      