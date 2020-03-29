-- Что касается вопроса про SQL со статьями и тэгами - мне кажется слишком легкий вопрос, даже не "лидеры в зарплатах по департаментам" :)
-- В общем, чтобы отобразились в т.ч. статьи без соответствующих тэгов нужен left outer join вместо inner
-- а многие-ко-многим обычно определяется добавчной таблицей свзки primary ключей обеих таблиц (Article, Tag):

select
  a.Header as [Article]
  t.Value as [Tag]  		-- to beautify we could do IsNull(t.Value, '') which would output a blank instead of NULL on missing tags.
  from Article as a
    left join ArticleTagLink as atl on atl.ArticleID = a.ArticleID 
    left join Tag as t on t.TagID = atl.TagID
order by a.ArticleID, t.Value; 	-- just sorting for the sake of visibility
