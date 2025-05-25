# Maui2Blazor
Extend Blazor Web Assembly power with .NET MAUI API.

PRO
- Reuse all .NET MAUI ViewModels
- Reuse with a very simple refactor .NET MAUI Views
- Prism style Navigation
- .NET MAUI style navigation (not tested)
- Free from .NET MAUI Handlers/Architecture

CONS
- INotifyProperyChanged Dependencies 

<img width="1312" alt="Screenshot 2025-05-25 alle 19 40 26" src="https://github.com/user-attachments/assets/c71d8e5a-8b97-4a0d-8d43-65328fa82801" />

```
@inherits ContentPageBase

@{var bc = BindingContext as CollectionViewPageViewModel;}

<Grid
      Margin="@Thickness.GetUniformCss(10)"
      RowSpacing="10"
      RowDefinitions="Auto, *">

    <GridItem>

        <Button Text="Reload data"
                CommandParameter="@bc"
                Command="@bc.ReloadClickCommand" />
    </GridItem>
    

    <GridItem
              GridRow="1">
        <CollectionView
                ItemsSource="@bc.ItemsList">

            <EmptyView>
                <Label
                       HorizontalTextAlignment="TextAlignment.Center"
                       VerticalOptions="LayoutOptions.Center"
                       FontSize="20"
                       Text="Loading..."/>
            </EmptyView>

            <ItemTemplate>
                <CollectionViewItemView BindingContext="@context" />
            </ItemTemplate>

        </CollectionView>

    </GridItem>
    
</Grid>
```

<img width="1312" alt="Screenshot 2025-05-25 alle 19 43 02" src="https://github.com/user-attachments/assets/d6213363-195a-445a-a109-0fc842d034eb" />


```
@inherits ContentPageBase


<ScrollView>
    <StackLayout Spacing="10"
                 Margin="@Thickness.GetUniformCss(10)">

        <Label
               HorizontalTextAlignment="TextAlignment.Center"
               Text="@Count.ToString()"
               FontSize="50"
               />

        <Button OnClick="IncreseCount"
                Text="Increase counter" />

    </StackLayout>

</ScrollView>
```

## .NET MAUI API Available (Partial or Not Tested)
- ContentPage
- ContentView
- StackLayout
- Grid
- ScroolView
- Label
- Button
- CheckBox
- RadioButton
- CarouselView
- BoxView
- Entry
- Editor
- ActivityIndicator
- Frame
- Image
- Slider
- Switch
- TimePicker
- DatePicler
- WebView
- DataTrigger
- Display Alert
- MVVM Converter

## Prism
- NavigationService

## Mopups
- PopupService

- ## .NET MAUI API NOT Available at the moment
- TabbedPage
- Flyout Page

## How to use
1. Clone this repository
2. Run Maui2BlazorSamples

## Disclaimer
This is at the moment an experiment. Use at your own risk.
Is not raccomanded to use into a production evironment.

## Copyright and license
Code released under the [MIT license](https://opensource.org/licenses/MIT).

## Did you like ?
[Buy Me A Coffee](https://www.buymeacoffee.com/giuseppeDev)
