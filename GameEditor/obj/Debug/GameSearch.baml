   M S B A M L   `   `   `  ����E  AGameEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:GameEditor
GameEditor  5          GameEditor.GameSearch   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:GameEditor     5        N� Title$  
GameSearch��5	       J� Opacity$ 1Q�6    N� 
Background
 �����.��5      � .+�5   
   �� -   5         ��Name$ 
CompanyBox��5      $��43,55,457,332q�6(    �� DisplayMemberPath$
 Name��6g    �� SelectedValuePath$ Id��6�   $��Stretch=�6�   $��Stretch=�6�   $	��100��6�   ��6@   ��  �� Path$ 	companies�6�   �� 5   
   -   5        $ GenreBox��5      $��203,55,297,332q�6&   $
 Name��6b   $ Id��6{   $��Stretch=�6�   $��Stretch=�6�   $	��100��6�   ��6>   �� $ genres�6�   �� 5   
   -   5         ��Name$ 	GamesList��5      $ Id��6J   $
��Left=�6a   $	��250��6|   $��	24,95,0,0q�6�   $	��Top=�6�   $	��556��6�   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6�   ��6&   �� $ games�	 �� View	 5      �� 5      .P�5      �� $��Title��6%   
 �� Width$	
 100��64    �� DisplayMemberBinding 5   %   �� *Title+�� 5      $��Company��6%   $	
 100��66    5   %   �� *CreatorCompany.Name+�� 5      $��Genre��6%   $	
 100��64    5   %   �� *
Genre.Name+�� 5      $��Rating��6%   $	
 100��65    5   %   �� *Rate+�� 5      $��Price��6%   $	
 100��64    5   %   �� *Price+5      5      �� 5   
   -   5         ��Name$ button��5      $��apply filters��6!   $
��Left=�69   $��189,370,0,0q�6T   $	��Top=�6i   $��88��6�   6�   �� 5   
   -   5         ��Name$ 	textBlock��5      $
��Left=�6'   $��
395,26,0,0q�6B   $
��Wrap=�6V   $��OrderBy:��6j   $	��Top=�6z   	� 5    
   -   5         	�Name$ 
PriceRadio��5       $��Price��6*   $
��Left=�6:   $��
353,55,0,0q�6U   $	��Top=�6i   $��48��6�   	� 5!   
   -   5        $ 	RateRadio��5!      $��Rating��6)   $
��Left=�6:   $��
439,55,0,0q�6U   $	��Top=�6i   �� 5"   
   -   5        $ Export��5"      $��Export games��6!   $
��Left=�68   $��
64,370,0,0q�6S   $	��Top=�6g   $��88��6   6�   �� 5#   
   -	   5        $ 
textBlock1��5#      $
��Left=�6(   $��	53,27,0,0q�6C   $
��Wrap=�6V   $��GameCompany��6j   $	��Top=�6}   �� 5$   
   -
   5        $ 
textBlock2��5$      $
��Left=�6(   $��
243,27,0,0q�6C   $
��Wrap=�6W   $��Genre��6k   $	��Top=�6x   �� 5%   
   -   5        $
 Edit��5%      $��Edit Selected��6   $
��Left=�67   $��311,370,0,0q�6R   $	��Top=�6g   $��88��6   6�   �� 5&   
   -   5        $ Delete��5&      $��Delete Selected��6!   $
��Left=�6;   $��439,370,0,0q�6V   $	��Top=�6k   $��98��6�   6�   5(      5)      