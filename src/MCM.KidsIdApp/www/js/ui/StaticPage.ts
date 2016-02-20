
module MCM{
  export class StaticPageCrl{
    constructor(){

    }
  }

  export class StaticPageDir{
    constructor(){
      return {
        scope:{'pageReference':'=ref'},
        restrict:"E",
        link:(scope, ele, attrs, controllers, transcludeFn)=>{

        },
        template:"<div>This Is A Test</div>"
      }
    }
  }
}
