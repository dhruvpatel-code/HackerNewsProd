import { Component, Inject, OnInit } from '@angular/core';
import { Articles } from './Models/articles';
import { HackerService } from './Services/hacker.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  
})
export class AppComponent implements OnInit {
  title = 'HackerNews';
  articleList: Articles[] = new Array<Articles>();
  page: number = 1;
  count: number = 0;
  tableSize: number = 20;
  tableSizes: any = [3, 6, 9, 12];
  searchText: any
  constructor(private articleService: HackerService) { };

  ngOnInit() {
    this.getArticles();
  }

  getArticles() {
    this.articleService.getArticle().subscribe(result => {
      this.articleList = result;
    })
  }

  onTableDataChange(event: any) {
    this.page = event;
    this.getArticles();
  }
  onTableSizeChange(event: any): void {
    this.tableSize = event.target.value;
    this.page = 1;
    this.getArticles();
  }


}
