   M S B A M L   `   `   `  ????F  BTimeManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TimeManagerTimeManager  5   	       TimeManager.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:TimeManager     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	     ? 
ResizeMode$  NoResize=?5	   	    ? WindowStyle$
 None=?5
   	    ? AllowsTransparency .  ? Title$ 时间管理??5   	   $	??654??6   $	??240??6$    ? DataContext 5   	   ??    Locator ?? Source# [   ?? Path$
 Main???5      ?? 5   
    ?? Opacity$ 0Q?6    ?? Color$ Transparent??6&   	 ? 	Resources	 5        SquareBtnStyle
 ?? 
TargetType ?? Property ?? Value ?? Triggers P? Property P? Value??%H  &	       ?? 5   
   "
 ??6'   .?5      ??  ? ??$ Right=?64   ?? 5       ? ??$ 36??6&    5      P? 5       ?@J?IsMouseOver . . ?5      ??  ?@J?Opacity$ 1Q?60   5      P? 5       ?@J?IsMouseOver .  . ?5      ??  ?@J?Opacity$	 0.9Q?60   5      5      5      .??5      ?  ? RowDefinitions 5    
   ?? 5!      $??40 ?6   ?? 5"      $??60 ?6   ?? 5#      $??40 ?6   ?? 5$      $??24 ?6   ?? 5%      $??40 ?6   ?? 5&      $??50 ?6   ?? 5'      $??40 ?6   ?? 5(      $??* ?6   .+?5,   
   ?? $??2??6     BgBorderStyle#??[ 6   $
??Left=?6E   $	??160??6`   ?? 5-   
   $??3??6   #??[ 6   ?? 5.   
   $??4??6   #??[ 6   y?6E   ?? *Rest+?? 5/   
   $??5??6   #??[ 6   y?6E   ?? *Rest+?? 50   
   $??6??6   #??[ 6   y?6E   ?? *Rest+?? 52   
   -   5        $
??Left=?52      $	??200??6,   #??[ 68   ._?53      ?? -   5        $??nowTime??53      $
??Left=?6   $??Center=?63   $	??180??6?   $??14(?6?   $
??Bold"?6?   $??12,0,0,0q?6?   ??6O   ?? *	NowStatus+ ?? FallbackValue$ 加载中...????6?   ?? *	BgBrush+6?   54      ?? 55   
   -   5        #???  55      ??56      ?? 57      .R?58      ?? $??36??6   #??[ 6(    J? Opacity$ 1Q?6O   ._?59      ?? $??Resources/#iconfont)?6$   $??20(?6E   $	????6r   $??Center=?6?   $??Center=?6?   ??6S   ?? *	BgBrush+6?   5:      5;      5=      ?? 5?   
   $??56??6    ?? CornerRadius$ 8??6   $??1??6N   $??0,2,0,2q?6[   ??6/   ?? *	BgBrush+6[   ?? 5@   
   -   5         ??Name$ timeSpanTxt??5@      
???????$??1??6p   $??36(?6}   $
??Bold"?6?   $??Center=?6?   $??Center=?6?   ??6)   ?? *NowTimeSpan+$ 00:00:00??6?   ?? 5B   
    ?? Orientation$ 
Horizontal=?6   $??2??6.   $??Center=?6;   $??0,0,80,0q?6X   .+?5C      	? $??早班??6     RadioButtonStyle#???  6'   
???????$??14(?6e   $?? ??6?    d? 	IsChecked 6s   ?? *	IsChecked+ ?? Mode$ TwoWay=?6?   	? 5D      $??晚班??6   #???  6'   
???????$??14(?6e   $??4,0,0,0q?6s   5E      ?? 5F   
   #???  6   $??0,0,40,0q?6:   $??2??6L   ??6Y   ?? *RestCommand+??5G      ?? 5H      .R?5I      ?? $??36??6   #??[ 6(   $ 1Q?6O   ._?5J      ?? $??Resources/#iconfont)?6$   $??20(?6E   $	????6r   $??Center=?6?   $??Center=?6?   ??6S   ?? *	BgBrush+6?   5K      5L      5N      ?? 5O   
   -   5        $??2??5O      #???  6   ??5P      ?? 5Q      .R?5R      ?? $??36??6   #??[ 6(   $ 1Q?6O   ._?5S      ?? $??Resources/#iconfont)?6$   $??20(?6E   $	????6r   $??Center=?6?   $??Center=?6?   ??6S   ?? *	BgBrush+6?   5T      5U      5W      ?? 5Y   
   $ 
Horizontal=?6   $??4??6.   y?6;   ?? *Rest+.+?5Z      ?? $	????6   $??Center=?6G   $??20(?6b   $??8,0,8,0q?6p   $??Resources/#iconfont)?6?   ??6(   ?? *	BgBrush+6?   ?? 5[      -   5        $
 tips??5[      $??14(?6`   $
??Bold"?6n     TitleTxt#???  6?   ??6'   ?? *
TipsInfo+$&  摸鱼小助手闪亮登场^-^)*??6?   5\      ?? 5^   
   $??3??6   $??Center=?6"   .+?5_      ?? $??Center=?6   $#?? Designed For HuangYan ??66   $??12(?6e   ???	#80000000$??Resources/#iconfont)?6?   5`      ?? 5b   
   $ 
Horizontal=?6   $??5??6.   y?6;   ?? *Rest+.+?5c      ?? $??Center=?6   $??追剧??65   $
??auto??6A   $??14(?6N   $
??Bold"?6{   $??8,0,82,0q?6?   ??6\   ?? *	BgBrush+6?   ?? 5d      -   5         ??Name$ aQiYi??5d        tvButtonStyle#??[ 6$   ??5e      ?? 5f      .R?5g      ?? $??/Resources/aqiyi.png??6    $??32??6>   $??32??6I   $
??Fill=?6U   5h      5j      ?? 5k      -   5        $ tencent??5k      #??[ 6&   ??5l      ?? 5m      .R?5n      ?? $??/Resources/tx.png??6    $??32??6;   $??32??6F   $
??Fill=?6R   5o      5q      ?? 5r      -	   5        $ mangGuo??5r      #??[ 6&   ??5s      ?? 5t      .R?5u      ?? $??/Resources/mg.jpg??6    $??32??6;   $??32??6F   $
??Fill=?6R   5v      5x      5y      ?? 5{   
   $??6??6   $??Center=?6"   $ 
Horizontal=?6=   y?6V   ?? *Rest+.+?5|      ?? $??Center=?6   $??	热搜榜??64   $
??auto??6A   $??14(?6N   $
??Bold"?6{   $??8,0,84,0q?6?   ??6\   ?? *	BgBrush+6?   ?? 5}      -
   5        $ platformBtn??5}       ? Cursor$
 Hand??6*   ??68   ?? *OpenPopCommand+??5~      ?? 5      .R?5?      ?? $??98??6!   $??28??6,   $ 8??6W   ??68   ?? *	BgBrush+._?5?      ?? $ 
Horizontal=?6)   $??Center=?6B   .+?5?   "   ?? $??Center=?6G   $??70??6b   $
??Bold"?6m   
??????? ?? TextAlignment$ Center=?6?   ??6,   ?? *
ItemName+6?   ?? 5?   "   $	????6,   
???????$??Resources/#iconfont)?6O   $??Center=?6p   $??Right=?6?   5?      5?      5?      5?      5?      ? 5?   
   $??Slide=?6.   $??Bottom=?6z    ? AllowsTransparency .  ? 	StaysOpen .  $??2??6?   $??2??6?   ??6   ?? *	PopIsOpen+ ? PlacementTarget 6F   ??  ?? ElementName$ platformBtn??.??5?      ?? ???#ffffff$ 12??6*   ._?5?      ?? $??8,0,8,0q?6   .+?5?      ?? $??微博??6   $??Center=?6+   $??Center=?6H   $??0,12,0,0q?6d   $
 Hand??6v     Pop_NumButton#??[ 6?   ??6?   ?? *	BgBrush+??6?   ?? *SearchCommand+??6?   ??  ?? RelativeSource ??   ?? Mode$
  Self=?$ Content??? 5?      $??抖音??6   $??Center=?6-   $??Center=?6J   $
 Hand??6g   #??[ 6?   ??6u   ?? *	BgBrush+??6?   ?? *SearchCommand+??6?   ??  ?? $
  Self=?$ Content??? 5?      $??快手??6   $??Center=?6-   $??Center=?6J   $
 Hand??6g   #??[ 6?   ??6u   ?? *	BgBrush+??6?   ?? *SearchCommand+??6?   ??  ?? $
  Self=?$ Content??? 5?      $??知乎??6   $??Center=?6-   $??Center=?6J   $
 Hand??6g   #??[ 6?   ??6u   ?? *	BgBrush+??6?   ?? *SearchCommand+??6?   ??  ?? $
  Self=?$ Content??? 5?      $??哔哩哔哩??6   $??Center=?6/   $??Center=?6L   $
 Hand??6i   #??[ 6?   ??6w   ?? *	BgBrush+??6?   ?? *SearchCommand+??6?   ??  ?? $
  Self=?$ Content?5?      5?      5?      ?? 5?   
   -   5        ! ??Name$
! list??5?      $	??240??6?   $??7??6o   
?????? $??0q?6?   $??Hidden=?6?   $??Hidden=?6?   y?6#   ?? *Rest+??6K   ?? *HotSearches+*  $Microsoft.Xaml.Behaviors.Interaction"   Triggers" 5?      +  %Microsoft.Xaml.Behaviors.EventTrigger  5?      #   	EventName$# SelectionChanged??6!   *  $Microsoft.Xaml.Behaviors.TriggerBase$   Actions.$ 5?      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction  %   Command% 6,   ?? *OpenUrlCommand+&   CommandParameter& 6O   ?? $
 list??$ SelectedIndex?5?      ??5?      ?? 5?      "
 ??6   ' ?? BasedOn#' [B??6;   .?5?      -   5        ?? 5?       ? ?? 5?      ?? 5?      ( ?? 
TargetType"( ??6.   .R?5?   "   ?? 5?      5?      5?      ??5?      ?? 5?      .R?5?      ?? ) ??Name$) border??6   $	??240??6-   $??32??69   
???????$ 8??6X   $??0,0,0,4q?6i     ListItemBorderStyle#???  6z   ._?5?      ?? $ 
Horizontal=?6%   $??Center=?6>   .+?5?      ?? $
??Bold"?6a   $??14(?6s   $??8,0,4,0q?6?   $??18??6?   ??6(   ?? *Count+??6?   ?? *
CountBrush+6?   ?? 5?      ???	#90000000$
??Bold"?6V   $??12(?6h   $??Center=?6v   $	??200??6?   $??CharacterEllipsis=?6?   ??6(   ?? *Title+6?   ?? 5?      $ urlTxt??6(   $y?	Collapsed=?6M   ??68   ?? *Url+6M   5?      5?      5?      5?      5?      5?      