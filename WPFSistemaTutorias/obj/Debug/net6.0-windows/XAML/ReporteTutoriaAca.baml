   M S B A M L   `   `   `  ����M  IWPFSistemaTutorias, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:WPFSistemaTutorias.XAMLWPFSistemaTutorias.XAML  5   	   /    )WPFSistemaTutorias.XAML.ReporteTutoriaAca   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:WPFSistemaTutorias.XAML     5   	     � Title$  ReporteTutoriaAca��5   	   $	��450��6#   $	��800��60   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgEstudiantes��5
         AutoGenerateColumns$ False��6+   $��56,142,56,82q�6G      CanUserAddRows$ False��6]      CanUserResizeColumns$ False��6t      CanUserReorderColumns$ False��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6V   	   
IsReadOnly$
	 True��6`   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 65   �� *nombreSesion+6`   4  .System.Windows.Controls.DataGridCheckBoxColumn  5      -   5        asistio��$ 
Asistencia��5   :   $ * 6v   
 6N   �� *asistenciaSeleccion+6v     5      -   5        
riesgo��$ Riesgo��5   9   $ * 6m   
 6I   �� *riesgoSeleccion+6m     5      $ Observaciones��6%   $ * 6d   
 6<   �� *observacionesSesion+6d   5      �� 5   
   $����Seleccione los estudiantes asistentes a la sesión de tutoría, y de ser el caso, marque si están 
en riesgo. Agregue además observaciones individuales��6   $��	56,72,0,0q�6�   $��42��6�   $	��519��6�   $��Stretch=�6�   $��Bottom=�6  $
��Left=�6&  $	��Top=�6A  $��Italic$�6Y  �� 5   
   -   5        $��Cancelar��5      $
��Left=�6$   $��642,372,0,0q�6?   $	��Top=�6T   ���	#FFEA8F8F$��26��6�   $	��104��6�   6�   �� 5   
   -   5        $��Guardar��5      $
��Left=�6#   $��514,372,0,0q�6>   $	��Top=�6S   ���	#FF8BAB9A$��28��6�   $	��104��6�   6�   �� 5   
   -   5         ��Name$ lbBienvenida��5      $�� ��6&   $
��Left=�61   $��	56,36,0,0q�6L   $	��Top=�6_   $	��405��6w   $
��Bold"�6�   $��16(�6�   $��31��6�   5      5      