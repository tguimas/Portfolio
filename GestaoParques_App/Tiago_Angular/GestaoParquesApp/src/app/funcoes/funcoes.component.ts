import { Component } from '@angular/core';

@Component({
  selector: 'app-funcoes',
  templateUrl: './funcoes.component.html',
  styleUrl: './funcoes.component.css'
})
export class FuncoesComponent {
  currentComponent: string = 'none';

  openComponent(hyperlink: any) {

    if (hyperlink) {
      if (hyperlink.id == "list")
        this.currentComponent = "list-funcoes";
      else if (hyperlink.id == "create")
        this.currentComponent = "create-funcoes";
      else if (hyperlink.id == "update")
        this.currentComponent = "update-funcoes";
      else if (hyperlink.id == "read")
        this.currentComponent = "read-funcoes";
      else if (hyperlink.id == "delete")
        this.currentComponent = "delete-funcoes";
      else
        this.currentComponent = '';
    }
  }
}
