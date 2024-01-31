import TopicElementInfo, { topicTypeMap } from "../../../../commonTypes/TopicElementInfo";

interface TopicContentItemProps {
    item: TopicElementInfo;
    isEditable: boolean;
}
// Component that decides what type of content is currently shown
function TopicContentItem ({item, isEditable}:TopicContentItemProps) {
    // We take value from the map to show it for this piece of topic
    const ContentType = topicTypeMap[item.type];
    return <ContentType innerText={item.innerText} isEditable={isEditable} />;
}

export default TopicContentItem;