import TopicElementInfo, { topicTypeMap } from "../../../../commonTypes/TopicElementInfo";

interface TopicContentItemProps {
    item: TopicElementInfo;
    isEditable: boolean;
}

function TopicContentItem ({item, isEditable}:TopicContentItemProps) {

    const ContentType = topicTypeMap[item.type];
    return <ContentType innerText={item.innerText} isEditable={isEditable} />;
}

export default TopicContentItem;