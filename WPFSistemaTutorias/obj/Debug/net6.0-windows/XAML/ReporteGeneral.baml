   M S B A M L   `   `   `  ����M  IWPFSistemaTutorias, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WPFSistemaTutoriasWPFSistemaTutorias  5   	   '    !WPFSistemaTutorias.ReporteGeneral   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:WPFSistemaTutorias     5   	     � Title$  ReporteGeneral��5   	   $	��609��6    $	��800��6-   .��5	      � $	��NaN��6    � RowDefinitions 5
   
   �� 5      $
��193* �6   �� 5      $
��400* �6   .+�5   
   �� -   5         ��Name$ cbPeriodoEscolar��5      $
��Left=�6-   $��	38,92,0,0q�6H   $	��Top=�6[   $	��300��6s   $��27                   ��6   �� 5   
   -   5        $ cbNumeroSesion��5      $
��Left=�6+   $��
354,92,0,0q�6F   $	��Top=�6Z   $	��167��6r   $��27��6~   �� 5   
   $��Periodo escolar��6   $
��Left=�6*   $��	38,61,0,0q�6E   $	��Top=�6X   �� 5   
   $��Número de sesión��6   $
��Left=�6+   $��
354,61,0,0q�6F   $	��Top=�6Z   �� 5   
   $g��aBienvenido (a), seleccione los filtros para consultar el Reporte General de Tutorías Académicas��6   $
��Left=�6z   $��	38,19,0,0q�6�   $	��Top=�6�   $��Italic$�6�   �� 5   
   -   5        $��	Consultar��5      $
��Left=�6%   $��
545,92,0,0q�6@   $	��Top=�6T   $��27��6l   $	��137��6x   6�   �� 5   
   $ ��Porcentaje de asistencias:��6   $
��Left=�65   $��
38,154,0,0q�6P   $	��Top=�6d   $	��150��6|   �� 5   
   $��Porcentaje de riesgo:��6   $
��Left=�60   $��320,154,0,0q�6K   $	��Top=�6`   $	��127��6x   �� 5   
   -   5         ��Name$ lbPorcentajeRiesgo��5      $�� ��6,   $
��Left=�67   $��447,154,0,0q�6R   $	��Top=�6g   $	��100��6   �� 5   
   -   5        $ lbPorcertajeAsistenca��5      $�� ��6/   $
��Left=�6:   $��185,154,0,0q�6U   $	��Top=�6j   $	��100��6�   �� 5   
   -   5         ��Name$ listBoxProblematicas��5      $	��NaN��6[   $��38,48,38,258q�6h   $	��NaN��6~   $��1��6�   �� 5   
   $��Problematicas reportadas��6   $
��Left=�63   $��	38,17,0,0q�6N   $	��Top=�6a   $��1��6y   �� 5   
   $��Comentarios generales��6   $
��Left=�60   $��
38,175,0,0q�6K   $	��Top=�6_   $��1��6w   �� 5   
   -   5        $ listBoxComentarios��5      $	��NaN��6Y   $��38,214,38,92q�6f   $	��NaN��6|   $��1��6�   �� 5   
   -   5        $��Cerrar��5      $
��Left=�6"   $��657,344,0,0q�6=   $	��Top=�6R   $��27��6j   $	��105��6v   ���	#FFEA8F8F$��1��6�   6�   �� 5   
   -	   5         ��Name$ btnImprimir��5      $��Imprimir��6&   $
��Left=�69   $��522,344,0,0q�6T   $	��Top=�6i   $��27��6�   $	��104��6�   ���	#FF8BAB9A$��1��6�   6�   5      5       