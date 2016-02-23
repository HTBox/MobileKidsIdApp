/// <reference path="../Definitions/angular.d.ts" />
/// <reference path="../models/models.ts" />


module MCM{
  export class ChildDataService{
    private _children: Child[];

    public static $inject=[];

    constructor(){
      this._children = [];
    }

    public add(add: Child):any{
      if(!add || !add.id){
        return false;
      }
      else if(this.hasChild(add.id)){
        return false;
      }

      return this._children.push(add);
    }


    public get(get:Child){
      if(!get || !get.id){
        return null;
      }

      return this.findChild(get.id);
    }

    public getById(id: number): Child{
      return this.findChild(id);
    }

    public update(upd: Child):any{
      if(!upd || !upd.id){
        return false;
      }

      var child = this.findChild(upd.id) || upd;
      if(child){
        var props = Object.getOwnPropertyNames(upd);
        props.forEach((property, index)=>{
          child[property]=upd[property];
        });
      }
      else{
        this._children.push(upd);
      }
      return child;
    }

    public delete(del:Child){
      if(!del || !del.id){
        return false;
      }
      for(var i = this._children.length-1; i >= 0; --i){
        if(this._children[i].id == del.id){
          this._children.splice(i, 1);
          return true;
        }
      }
      return false;
    }


    private hasChild(childId){
      this._children.some((child:Child)=>{return (child.id === childId);})
    }
    private findChild(childId){
      return this._children.filter((child:Child)=>{return (child.id === childId);})[0] || null;
    }
  }
}

angular.module('mcmapp').service('ChildDataService', MCM.ChildDataService);
