function back() {
    Pageredirect("/ClientMaster/ClientDashboard")
}
function ClientDetails(cid) {
    Pageredirect("/ClientMaster/ClientDetails/" + cid);
}
function edit(cid) {
    Pageredirect("/ClientMaster/ClientEdit/" + cid);
}