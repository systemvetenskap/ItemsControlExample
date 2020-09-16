# Dynamiska cirklar
Det här exemplet visar hur man kan lägga till komponenter dynamiskt i ett XAML-dokument.

Fundamentet utgörs av en ItemsControl, som är en komponent som listar egentligen vadhelst den tilldelas.

```cs
<ItemsControl>
    <Label Content="Erik" />
    <Label Content="Yasmine" />
    <Label Content="Mohamed" />
</ItemsControl>
```
## Bindings
Som i de flesta andra fall så kan man istället binda en ItemsControl till en property. Tänk er att ni har en samling pegs i en lista. Varje enskild sådan Peg borde då också kunna ha en egen vymodell. Enda propertyn jag lägger där i mitt exempel är vilken gissning användaren gjort:

```cs
public class PegViewModel
{
    public PegPosition GuessResult { get; set; }
}
```

I Vymodellen som därefter ligger till grund för Vyn som ska presentera dessa färglada pluppar skapar jag en lista av typen PegViewModel
```cs
public ObservableCollection<PegViewModel> Pegs { get; set; }
```

Vi kan nu alltså koppla samman egenskapen Pegs med vår ItemsControl
```cs
 <ItemsControl ItemsSource="{Binding Pegs}">
 ```
 
Och fylla denna med våra ellipser. Gör detta som en innehållsmall, item Template
```cs
<ItemsControl.ItemTemplate>
    <DataTemplate>
        <Ellipse 
            Stroke="Black" 
            StrokeThickness="1"  
            Fill="{Binding GuessResult, Converter={StaticResource ColorConverter}}" 
            Width="50 " 
            Height="50"
            Margin="5"/>
    </DataTemplate>
</ItemsControl.ItemTemplate>
```

Om man dessutom vill få till att man har dessa pluppar i grupper om säg fyra stycken. Då kan man lägga till en mall även för själva kontrollen. I denna lägger vi in komponenten Uniform grid. Hela koden för detta blir då:

```cs
<ItemsControl ItemsSource="{Binding Pegs}" Grid.Row="1" Grid.Column="1">
    <ItemsControl.ItemsPanel>
        <ItemsPanelTemplate>
            <UniformGrid Columns="4"/>
        </ItemsPanelTemplate>
    </ItemsControl.ItemsPanel>
    <ItemsControl.ItemTemplate>
        <DataTemplate>
            <Ellipse 
                Stroke="Black" 
                StrokeThickness="1"  
                Fill="{Binding GuessResult, Converter={StaticResource ColorConverter}}" 
                Width="50 " 
                Height="50"
                Margin="5"/>
        </DataTemplate>
    </ItemsControl.ItemTemplate>
</ItemsControl>
```

Färgen konverteras sedan med stöd av en ColorConverter.



