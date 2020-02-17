import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HiveSection } from '../models/hive-section';
import { HiveSectionService } from '../services/hive-section.service';


@Component({
  selector: 'app-hive-section-form',
  templateUrl: './hive-section-form.component.html',
  styleUrls: ['./hive-section-form.component.css']
})
export class HiveSectionFormComponent implements OnInit {

  hiveSection = new HiveSection(0, "", "", false, "", 0);
  storeHiveId: number;
  existed = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private hiveSectionService: HiveSectionService
  ) {
  }

  ngOnInit() {
    this.route.params.subscribe(p => {
      if (p['storeHiveId'] != undefined) {
        this.storeHiveId = p['storeHiveId'];
        this.existed = false;
      }

      if (p['id'] === undefined) {
        return;
      }
      else {
        this.hiveSectionService.getHiveSection(p['id']).subscribe(c => this.hiveSection = c);
        this.existed = true;
      }
    });
  }

  navigateToSections() {
    if (this.storeHiveId != undefined) {
      this.router.navigate([`/hive/${this.storeHiveId}/sections`]);
    }
    else {
      this.router.navigate([`/hive/${this.hiveSection.storeHiveId}/sections`]);
    }   
  }

  onCancel() {
    this.navigateToSections();
  }

  onSubmit() {
    if (this.existed) {
      this.hiveSectionService.updateHiveSection(this.hiveSection).subscribe(() => this.navigateToSections());
    } else {
      this.hiveSection.storeHiveId = this.storeHiveId;
      this.hiveSectionService.addHiveSection(this.hiveSection).subscribe(() => this.navigateToSections());
    }
  }

  onDelete() {
    this.hiveSectionService.setHiveSectionStatus(this.hiveSection.id, true)
      .subscribe(() => this.hiveSection.isDeleted = true);
  }

  onUndelete() {
    this.hiveSectionService.setHiveSectionStatus(this.hiveSection.id, false)
      .subscribe(() => this.hiveSection.isDeleted = false);
  }

  onPurge() {
    this.hiveSectionService.deleteHiveSection(this.hiveSection.id).subscribe(() => this.navigateToSections());
  }
}
