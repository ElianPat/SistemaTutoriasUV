   M S B A M L   `   `   `  ����M  IWPFSistemaTutorias, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:WPFSistemaTutorias.XAMLWPFSistemaTutorias.XAML  5   	   4    .WPFSistemaTutorias.XAML.registrarHorarioSesion   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:WPFSistemaTutorias.XAML     5   	     � Title$/  )Registrar horario de sesión de tutorías��5   	   $	��450��69   $	��800��6F   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��8* �6   �� 5      $	��29* �6   �� 5      $	��13* �6   .+�5   
   �� -   5        $��Cancelar��5      $
��Left=�6$   $��454,373,0,0q�6?   $	��Top=�6T   $��38��6l   $��86��6x   $��2��6�   $��1��6�   �� 5   
   -   5        $��Guardar��5      $
��Left=�6#   $��100,373,0,0q�6>   $	��Top=�6S   $��38��6k   $��86��6w   $��2��6�   �� 5   
   -   5         ��Name$ lblTutor��5      $�� ��6"   $
��Left=�6-   $��	22,10,0,0q�6H   $	��Top=�6[   $	��261��6s   $��2��6   �� 5   
   -   5         ��Name$ cbSesion��5      $
��Left=�6%   $��	7,129,0,0q�6@   $	��Top=�6S   $	��166��6k   $��31��6w   $��2��6�   �� 5   
   -   5        $ lblFecha��5      $�� ��6"   $
��Left=�6-   $��7,10,0,0q�6H   $	��Top=�6Z   $	��166��6r   $��2��6~   �� 5   
   -   5         ��Name$ 	tbHorario��5      $
��Left=�6%   $��	7,198,0,0q�6@   $	��Top=�6S   $	��166��6k   $��30��6w    �� TextWrapping$ WrapWithOverflow=�6�    �� TextAlignment$ Center=�6�   $��2��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgEstudiantes��5         AutoGenerateColumns$ False��6+   $��22,61,48,83q�6G   	   CanUserAddRows$	 False��6\   $��2��6s   
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Matricula��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6V      
IsReadOnly$
 True��6`   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *	matricula+6`     5      $ Nombre��6%   $ * 6P   $
 True��6Z    65   �� *nombre+6Z   5      �� 5   
   -   5        $ tbLugar��5      $
��Left=�6#   $��	7,272,0,0q�6>   $	��Top=�6Q   $	��166��6i   $��30��6u   $ WrapWithOverflow=�6�   $ Center=�6�   $��2��6�   �� 5   
   -	   5        $ 
cbPeriodos��5      $
��Left=�6'   $��7,63,0,0q�6B   $	��Top=�6T   $	��166��6l   $��31��6x   $��2��6�   �� 5   
   $��Periodo escolar
��6   $
��Left=�64   $��7,36,0,0q�6O   $	��Top=�6a   $��31��6y   $��2��6�   �� 5   
   $��Número de sesión
��6   $
��Left=�60   $��	7,103,0,0q�6K   $	��Top=�6^   $��2��6v   �� 5    
   $��Horario (00:00)
��6   $
��Left=�6/   $��	7,175,0,0q�6J   $	��Top=�6]   $��2��6u   �� 5!   
   $��Lugar
��6   $
��Left=�6%   $��	7,245,0,0q�6@   $	��Top=�6S   $��2��6k   5"      5#      