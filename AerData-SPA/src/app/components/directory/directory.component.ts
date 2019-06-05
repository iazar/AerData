import { DirectoryModel } from 'src/models/directory-model';
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-directory',
  templateUrl: './directory.component.html',
  styleUrls: ['./directory.component.css']
})
export class DirectoryComponent implements OnInit {
  directoriesList: DirectoryModel[];
  loading: boolean;
  constructor(private route: ActivatedRoute, private router: Router) {

  }
  ngOnInit() {
    this.route.data.subscribe(data => {
      this.directoriesList = data['directoriesList'];
    });
  }

}
