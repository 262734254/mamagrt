function floaters(className) {
    this.ClassName = className;
    this.CloseB = false;
    this.collection = null;
    this.delta = 0.015;
    this.items = [];
}
floaters.prototype.init = function(){
    this.collection = this.items
    setInterval(this.ClassName + ".play()",30);
}
    
floaters.prototype.addItem = function(id,x,y,w,content)
{
    document.write('<DIV id='+id+' style="Z-INDEX: 10; POSITION: absolute;  width:' + w + 'px; height:60px;left:'+(typeof(x)=='string'?eval(x):x)+';top:'+(typeof(y)=='string'?eval(y):y)+'">'+content+'</DIV>');
 
    var newItem    = {};
    newItem.object   = document.getElementById(id);
    newItem.x    = x;
    newItem.y    = y;

    this.items[this.items.length]  = newItem;
}
floaters.prototype.play = function(){
    if(screen.width<=800 || this.CloseB){
        for(var i=0;i<this.collection.length;i++){
            this.collection[i].object.style.display = 'none';
        }
        return;
    }
    for(var i=0;i<this.collection.length;i++){
        var followObj  = this.collection[i].object;
        var followObj_x  = (typeof(this.collection[i].x)=='string'?eval(this.collection[i].x):this.collection[i].x);
        var followObj_y  = (typeof(this.collection[i].y)=='string'?eval(this.collection[i].y):this.collection[i].y);

        if(followObj.offsetLeft!=(document.body.scrollLeft+followObj_x)) {
            var dx=(document.body.scrollLeft+followObj_x-followObj.offsetLeft)*this.delta;
            dx=(dx>0?1:-1)*Math.ceil(Math.abs(dx));
            followObj.style.left=followObj.offsetLeft+dx;
        }
        
    if(followObj.offsetTop!=(document.body.scrollTop+followObj_y)) {
        var dy=(document.body.scrollTop+followObj_y-followObj.offsetTop)*this.delta;
        dy=(dy>0?1:-1)*Math.ceil(Math.abs(dy));
        followObj.style.top=followObj.offsetTop+dy;
        }
    followObj.style.display = '';
    }
} 
floaters.prototype.closeBanner = function(){
    this.CloseB=true;
    return;
}

 
var theFloaters = new floaters("theFloaters"); 

theFloaters.addItem('followDiv2','document.body.clientWidth-60',50,60,'<div style="width:59px;"><EMBED src=/images/flash/wlxdl.swf quality=high  WIDTH=59 HEIGHT=383 TYPE=application/x-shockwave-flash id=ad wmode=opaque></EMBED><div style="width:59px;text-align:right;padding:3px 1px 0 0"><a href="JavaScript:theFloaters.closeBanner();" style="cursor: pointer"><u style="font-size:14px; color:#000000">¹Ø±Õ</u></a></div></div>');

theFloaters.addItem('followDiv3',0,50,60,'<div style="width:59px;"><EMBED src=/images/flash/wlxdl.swf quality=high  WIDTH=59 HEIGHT=383 TYPE=application/x-shockwave-flash id=ad wmode=opaque></EMBED><div style="width:50px;text-align:left;padding:3px 1px 0 0"><a href="JavaScript:theFloaters.closeBanner();" style="cursor: pointer"><u style="font-size:14px; color:#000000">¹Ø±Õ</u></a></div></div>');
theFloaters.init(); 






