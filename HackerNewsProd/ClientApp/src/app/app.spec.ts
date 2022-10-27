
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientModule } from '@angular/common/http';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { FormsModule } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination';
import { HackerService } from './Services/hacker.service';
import { AppComponent } from './app.component';
import { Ng2SearchPipe } from 'ng2-search-filter';


describe('AppComponent', () => {
  let component: AppComponent;
  let fixture: ComponentFixture<AppComponent>;
  let url : HackerService;

  beforeEach(async(() => {
    TestBed.configureTestingModule({

      imports: [
        HttpClientModule,
        HttpClientTestingModule,
        FormsModule,
        NgxPaginationModule,

      ],
      declarations: [AppComponent, Ng2SearchPipe],
      providers: [{ provide: 'https://localhost:44317/Hacker' }]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeDefined();
  });
})
